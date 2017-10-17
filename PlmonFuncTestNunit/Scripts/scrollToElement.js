function ScrollToElement(elCssSelector)
{
    var element = document.querySelector(elCssSelector);
    element.scrollIntoView();
    element.click();
}

ScrollToElement("@");







