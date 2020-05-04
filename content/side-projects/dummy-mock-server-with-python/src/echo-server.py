#!/usr/bin/env python
# https://unix.stackexchange.com/a/57939
#

import tornado.options
import tornado.ioloop
import tornado.web
import tornado.escape
import pprint
import json
from  urllib.parse import parse_qs


def get_model(l):
    t = parse_qs(l.request.body.decode('utf-8'))

    result = dict()

    for k, v in t.items():
        result[k] = v[0]
    return result


class GarantiCreditResultHandler(tornado.web.RequestHandler):
    def get(self):
        self.render("credit-result.html")

    def post(self):
        # print(self.request.body["OrderNumber"])
        # model = tornado.escape.json_decode(self.request.body)
        # data = tornado.escape.json_decode(self.request.body)

        # bind_args = dict((k,v[-1] ) for k, v in self.request.arguments.items())
        # print(bind_args)

        # data = parse_qs(str(self.request.body)

        model = get_model(self)
        print(model)
        self.render("credit-result.html", model=model)


class GarantiHashServiceHandler(tornado.web.RequestHandler):
    def post(self):
        self.set_header("content-type", "text/xml")
        resp = """
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"
xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-
instance">
   <soapenv:Header/>
  <soapenv:Body>
      <p144:ExecuteResponse xmlns:p144="http://RemoteApplicationAuth.webservices.gb.com">
         <p144:Response>
            <p144:OutHeader>
               <p144:IsSuccessfull>true</p144:IsSuccessfull>
               <p144:ResponseMessage/>
               <p144:ResponseCode>GEP0001001</p144:ResponseCode>
            </p144:OutHeader>
            <p144:ExpIdc1DcmApplToApplInfo>
               <p144:HashKeyText>E2678124F3AF770C619175817BB216B2</p144:HashKeyText>
</p144:ExpIdc1DcmApplToApplInfo>
            <p144:ExpHttpLink>
               <p144:Link>http://localhost:8080/garanti/credit-result?o=telpa&amp;t=PCWEB&amp;h=E2678124F3AF770C619175817BB216B2</p144:Link>
            </p144:ExpHttpLink>
            <p144:ExpMsgIdc1Component>
               <p144:SeverityCode>I</p144:SeverityCode>
               <p144:MessageTx>(@1,@2) GEP0001001:Hazır</p144:MessageTx>
            </p144:ExpMsgIdc1Component>
            <p144:ExpErrorIdc1Component>
               <p144:SeverityCode>I</p144:SeverityCode>
               <p144:RollbackIndicator></p144:RollbackIndicator>
               <p144:OriginServid>9001</p144:OriginServid>
               <p144:ContextString/>
               <p144:ReturnCode>1</p144:ReturnCode>
               <p144:ReasonCode>1</p144:ReasonCode>
               <p144:Checksum></p144:Checksum>
               <p144:DialectCd></p144:DialectCd>
            </p144:ExpErrorIdc1Component>
         </p144:Response>
      </p144:ExecuteResponse>
   </soapenv:Body>
</soapenv:Envelope>
"""
        self.finish(resp)


class MyDumpHandler(tornado.web.RequestHandler):
    def get(self):
        pprint.pprint(self.request)
        pprint.pprint(self.request.headers)
        pprint.pprint(self.request.body)

        self.finish(self.request.body)

    def post(self):
        pprint.pprint(self.request)
        pprint.pprint(self.request.headers)
        pprint.pprint(self.request.body)

        self.set_header("content-type", self.request.headers["content-type"])
        self.finish(self.request.body)


if __name__ == "__main__":
    urls = [
        (r"/garanti/hash-service", GarantiHashServiceHandler),
        (r"/garanti/credit-result", GarantiCreditResultHandler),
        # (r"/.*", MyDumpHandler),

    ]

    tornado.options.parse_command_line()
    tornado.web.Application(urls, autoreload=True).listen(8080)
    tornado.ioloop.IOLoop.instance().start()
