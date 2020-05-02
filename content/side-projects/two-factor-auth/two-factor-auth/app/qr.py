#!/usr/bin/env python
# coding:utf-8
import base64
from io import BytesIO

import qrcode as qrc


def qrcode(data, version=None, error_correction='M', box_size=4.5, border=2.5, fit=False):
    """
    makes qr image using qrcode as qrc See documentation for qrcode package for info
    taken from: https://github.com/agnerio/Flask-QRcode/blob/master/flask_qrcode/__init__.py
    """
    correction_levels = {
        'L': qrc.constants.ERROR_CORRECT_L,
        'M': qrc.constants.ERROR_CORRECT_M,
        'Q': qrc.constants.ERROR_CORRECT_Q,
        'H': qrc.constants.ERROR_CORRECT_H
    }

    qr = qrc.QRCode(
        version=version,
        error_correction=correction_levels[error_correction],
        box_size=box_size,
        border=border
    )
    qr.add_data(data)
    qr.make(fit=fit)

    # creates qrcode base64
    out = BytesIO()
    qr_img = qr.make_image()
    qr_img.save(out, 'PNG')

    return u"data:image/png;base64," + base64.b64encode(out.getvalue()).decode('ascii')
