function ScrollTop(elCssSelector) {
    var el = document.querySelector(elCssSelector);
    el.scrollTop = -5000;
    el.scrollTo(0, el.scrollTop);
}
ScrollTop("@");