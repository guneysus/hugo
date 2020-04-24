// for the search only version
import algoliasearch from 'https://cdn.jsdelivr.net/npm/algoliasearch@4/dist/algoliasearch-lite.esm.browser.min.js';

// for the default version
// import algoliasearch from 'https://cdn.jsdelivr.net/npm/algoliasearch@4/dist/algoliasearch.esm.browser.min.js';

// Replace with your own values
const searchClient = algoliasearch(
    'A49MXBQ14J',
    '08c994fdf5dedd20dbff3e48a8b4fbac' // search only API key, not admin API key
);

const index = searchClient.initIndex('blog.guneysu.xyz');

const updateResults = function (results) {
    var el = document.querySelector('.results');
    // document.querySelector('.results').style.borderWidth = "1px";
    el.innerHTML = null;
    results.forEach(result => {
        el.appendChild(result);
    });
}

const resultFactory = function (item) {
    var li = document.createElement('li');
    var a = document.createElement('a');
    let br = document.createElement('br');
    let span = document.createElement('span');
    span.innerHTML = item._highlightResult.description.value;

    var title = document.createElement('strong');
    title.innerHTML = item._highlightResult.title.value;

    a.href = item.url;
    a.appendChild(title);
    a.appendChild(br);
    a.appendChild(span);
    li.appendChild(a);
    return li;
}

function debounce(fn, delay) {
    var timeoutID = null
    return function () {
        clearTimeout(timeoutID)
        var args = arguments
        var that = this
        timeoutID = setTimeout(function () {
            fn.apply(that, args)
        }, delay)
    }
}

const onSearch = function (evt) {
    var query = evt.target.value;
    const settings = {
                attributesToHighlight: [
                  'title',
                  'url',
                  'description'
                ]
              };
        

    index.search(query, settings).then(function (response) {
        var posts = response.hits.filter(x => x.kind == 'page');

        var results = posts.map(item => {
            var li = resultFactory(item);
            return li;
        });
        updateResults(results);
    });
};

const onSearchDebounce = debounce(onSearch, 75);

document.querySelector("input[type=search]").addEventListener('keypress', onSearchDebounce);

document.querySelector("input[type=search]").addEventListener('focus', function () {
    document.querySelector('.results').style.display = "";
});

document.querySelector("input[type=search]").addEventListener('blur', function () {
    // document.querySelector('.results').style.borderWidth = "0px";        
    setTimeout(function () {
        document.querySelector('.results').style.display = "none";
    }, 200);
});

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.results').style.display = "none";
});
