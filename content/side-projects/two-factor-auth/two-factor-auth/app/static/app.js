/**
 * Created by ahmed on 10/25/16.
 */
        function verify() {
            //noinspection JSUnusedGlobalSymbols
            $.ajax({
                type: "POST",
                url: '/verify',
                data: {
                    secret: document.querySelector('[name=secret]').value,
                    pin: document.querySelector('[name=password]').value
                },
                success: (data) => {
                    console.info(data);
                    switch (data.result) {
                        case true:
                            console.log('%c Verified ', 'background: #bada55; color: black;');
                                swal("Good job!", "You clicked the button!", "success");
                            break;
                        case false:
                            console.log('%c Failed ', 'font-weight:bolder; background: red; color: black;');
                                swal(
                                        {
                                            title: "Error!",   text: "Here's my error message!",   type: "error",   confirmButtonText: "Cool" });
                            break;
                        default:
                            console.error("an error occured.")
                            break;
                    }
                },
                dataType: 'json'
            });
        }

        // event listener for keyup
        // noinspection JSUnusedLocalSymbols
        function checkTabPress(e) {
            "use strict";

            var KEYS = {
                TAB: 9,
                ENTER: 13,
            };

            // pick passed event or global event object if passed one is empty
            e = e || window.event;
            if (e == null) {
                return false;
            }

            switch (e.keyCode) {
                case KEYS.TAB:
                    console.error(e.keyCode);
                    CompleteEvent(e);
                    break;
                case KEYS.ENTER:
                    console.error(e.target);
                    verify();
                    break;
                default:
                    break;
            }

        }

        function CompleteEvent(e) {
            e.cancelBubble = true;
            e.returnValue = false;
        }
        $(function () {
            var passwordField = document.querySelector("[name=password]");
            passwordField.addEventListener("keydown", checkTabPress);
            passwordField.focus();
        });
