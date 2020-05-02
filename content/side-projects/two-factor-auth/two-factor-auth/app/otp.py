#!/usr/bin/env python
# coding:utf-8
import base64
import os


def secretor():
    text = base64.b32encode(os.urandom(10)).lower()
    n = 4
    text = ' '.join([text[i:i + n] for i in range(0, len(text), n)])
    return text


def otp_uri(secret, email='example@google.com', issuer='guneysu.xyz'):
    qrdata = 'otpauth://totp/{issuer}:{email}?secret={secret}&issuer={issuer}' \
        .format(secret=secret,
                email=email,
                issuer=issuer)
    return qrdata
