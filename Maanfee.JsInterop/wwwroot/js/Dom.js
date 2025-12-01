/*
 * JavaScript Library v0.0.4
 *
 *
 *
 * Date: 01-11-01
 */

// ========== DOM Manipulation ==========

export function querySelector(selector) {
    return document.querySelector(selector);
}

export function querySelectorAll(selector) {
    return Array.from(document.querySelectorAll(selector));
}

function _Selector(selector, selectors) {
    let elements = [];

    if (selector && selector !== "") {
        // Use querySelector - single element
        const element = querySelector(selector);
        if (element) {
            elements.push(element);
        }
    }
    else if (selectors && selectors !== "") {
        // Use querySelectorAll - multiple elements
        elements = querySelectorAll(selectors);
    }

    return elements;
}

// ========== Content Manipulation ==========

export function Text(selector, selectors, Content = null) {

    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    if (Content === null) {
        // GET mode - return text content
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.textContent || item.innerText || ''));
    } else {
        // SET mode - set text content
        elements.forEach(item => {
            item.innerHTML = Content;
        });
        return Content;
    }
}

export function HTML(selector, selectors, Content = null) {

    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    if (Content === null) {
        // GET mode - return text content
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.innerHTML));
    } else {
        // SET mode - set text content
        elements.forEach(item => {
            item.innerHTML = Content;
        });
        return Content;
    }
}

export function Val(selector, selectors, val = null) {

    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    if (val === null) {
        // GET mode - return val content
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.value));
    } else {
        // SET mode - set val content
        elements.forEach(item => {
            item.value = val;
        });
        return val;
    }
}

export function Attr(selector, selectors, attributeName = null, attributeValue = null) {

    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    if (attributeValue === null) {
        // GET mode - return attribute value
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.getAttribute(attributeName)));
    } else {
        // SET mode - set attribute value
        elements.forEach(item => {
            item.setAttribute(attributeName, attributeValue);
        });
        return attributeValue;
    }
}

// ========== Events ==========

export function OnClick(selector, selectors) {

    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    elements.forEach(item => {
        item.click();
   });
}