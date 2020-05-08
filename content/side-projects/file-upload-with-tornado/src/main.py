#!/usr/bin/env python
# coding:utf-8

import os
import uuid

from fs import open_fs
from tornado.web import Application, RequestHandler, url, StaticFileHandler

from tornado.httpserver import HTTPServer
from tornado.ioloop import IOLoop

fs = open_fs('osfs://uploads/')

class Userform(RequestHandler):

    def get(self):
        self.render("upload.html")



# noinspection PyAbstractClass
class AsyncFileUploadHandler(RequestHandler):
    """
    Uploader
    """

    def upload_async(self, filepart):
        filename = filepart['filename']
        extension = os.path.splitext(filename)[1]
        unique_name = str(uuid.uuid4()) + extension
        fs.setbytes(unique_name, filepart['body'])
        return unique_name

    def post(self):
        files = tuple(map(self.upload_async, self.request.files['file']))
        urls = tuple(map(lambda name: f'/uploads/{name}', files))
        data = dict(files=files, urls=urls)
        self.finish(data)


handlers = [
    (r"/", Userform),
    url(pattern=r'/upload', handler=AsyncFileUploadHandler, name='upload'),
    (r"/uploads/(.*)", StaticFileHandler, {"path": "uploads"})
]

App = Application(handlers=handlers, **dict(debug=False,
                                            autoreload=False, logging='debug'))
if __name__ == "__main__":
    server = HTTPServer(App)
    server.bind(port=8000)
    server.start(num_processes=1)
    IOLoop.current().start()
