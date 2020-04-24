
window.Bug = (function () {
    var _getCurrentPage = function () {
        return window.location.href;
    };

    var _getPathName = function () {
        return window.location.pathname;
    };

    var _getTitle = function () {
        var title = `Issue on page: ${_getPathName()}`;
        return encodeURIComponent(title);
    };

    var _getBody = function () {
        var body = `There is a :bug: ${_getCurrentPage()}`;
        return encodeURIComponent(body);
    };

    var _getLink = function () {
        return `https:\/\/github.com/guneysus/blog/issues/new?title=${_getTitle()}&body=${_getBody()}`;
    };

    var _report = function () {
        window.open(_getLink(), "_blank");
    };

    return {
        report: _report
    };
})();

var toggleTableOfContents = function () {
    var el = document.querySelector(".toc-container .toc");
    el.classList.toggle("hide");
    el.classList.toggle("show");
    // debugger;
    document.querySelector('button.toggle-toc').classList.toggle("collapsed");
}