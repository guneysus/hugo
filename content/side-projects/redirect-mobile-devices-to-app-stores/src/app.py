#!/usr/bin/env python
# coding:utf-8
from tornado.httpserver import HTTPServer
from tornado.ioloop import IOLoop
from tornado.options import options, define, parse_command_line
from tornado.web import RequestHandler, Application, url
from user_agents import parse

define(name="port", default=8000, help="Port")

STORE_URLS = {
    "iPhone": "https://itunes.apple.com/us/app/jokermenu/id1086543332?l=tr&ls=1&mt=8",
    "Android": "https://play.google.com/store/apps/details?id=com.menu.joker",
}


# noinspection PyAbstractClass
class HomeHandler(RequestHandler):
    def get(self):
        ua_string = self.request.headers.get('user-agent', '')
        os_family = self.get_os(ua_string)

        if os_family == "Android":
            # even on firefox it works, this does not work on chrome on android
            # see:
            # - https://bugs.chromium.org/p/chromium/issues/detail?id=454396
            # - http://stackoverflow.com/a/28279849/1766716
            # self.redirect(url="market://details?id=com.menu.joker", permanent=False)

            # intent name (install) and scheme (get) can be arbitrary strings.
            # only package parameter required
            self.redirect("intent://install#Intent;scheme=get;package=com.menu.joker;end")

        elif os_family == "iPhone":
            # self.redirect(url=STORE_URLS["iPhone"], permanent=False)
            self.redirect(url="itms://itunes.apple.com/us/app/apple-store/id1086543332?l=tr&ls=1&mt=8")
        else:
            self.redirect(url="https://joker.menu", permanent=False)

    @staticmethod
    def get_os(ua_string):
        user_agent = parse(ua_string)
        os_family = user_agent.os.family
        return os_family


urls = [
    url(pattern=r'/', handler=HomeHandler, name="home"),
]

application = Application(handlers=urls)


def main():
    server = HTTPServer(application)
    parse_command_line()
    server.listen(port=options.port, address="0.0.0.0")
    server.start(num_processes=1)
    IOLoop.instance().start()


if __name__ == '__main__':
    main()
