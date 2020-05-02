#!/usr/bin/env python
# coding:utf-8
import logging

import onetimepass as otp
from flask import Blueprint, Flask, jsonify, render_template, request

from app.otp import otp_uri, secretor
from app.qr import qrcode


class Application(Flask):
    def __init__(self, import_name, *args, **kwargs):
        super(Application, self).__init__(import_name, *args, **kwargs)
        module = Blueprint('qrcode', __name__, template_folder='templates')
        self.register_blueprint(module)

        self.add_template_filter(qrcode)
        self.add_template_global(qrcode)


app = Application(__name__)


@app.route('/verify', methods=['POST'])
def verify():
    secret = request.form['secret']
    pin = request.form['pin']

    logging.warn(secret)
    logging.warn(pin)

    password = otp.get_totp(secret=secret, as_string=True)

    return jsonify(result=pin == password)


@app.route('/')
def login():
    secret = secretor()
    qrdata = otp_uri(secret=secret)
    return render_template('login.html', qrdata=qrdata, secret=secret)
