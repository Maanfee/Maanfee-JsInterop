/*
 * JavaScript Library 0.2.0
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
        // GET
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.textContent || item.innerText || ''));
    } else {
        // SET 
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
        // GET
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.innerHTML));
    } else {
        // SET 
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
        // GET 
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.value));
    } else {
        // SET 
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
        // GET
        elements = Array.from(elements);
        return JSON.stringify(elements.map(item => item.getAttribute(attributeName)));
    } else {
        // SET 
        elements.forEach(item => {
            item.setAttribute(attributeName, attributeValue);
        });
        return attributeValue;
    }
}

export function AddClass(selector, selectors, className) {
    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    elements.forEach(el => el.classList.add(className));
    return className;
}

export function RemoveClass(selector, selectors, className) {
    let elements = _Selector(selector, selectors);
    if (elements.length === 0) return null;

    elements.forEach(el => el.classList.remove(className));
    return className;
}

export function ToggleClass(selector, selectors, className) {
    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    elements.forEach(el => el.classList.toggle(className));
    return className;
}

export function Css(selector, selectors, propertyName, val = null) {
    let elements = _Selector(selector, selectors);
    if (elements.length === 0) {
        return null;
    }

    if (val === null) {
        // GET
        const values = elements.map(el => {
            const inline = el.style[propertyName];
            return inline || getComputedStyle(el)[propertyName] || "";
        });

        // همیشه آرایه JSON برگردون (حتی اگه یه المان باشه)
        return JSON.stringify(values);
    } else {
        // SET
        elements.forEach(item => {
            item.style[propertyName] = val;
        });
        return val;
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

// ========== Event Listeners ==========

const _eventListeners = new Map();

export function AddEventListener(selector, selectors, eventName, dotNetHelper) {
    const elements = _Selector(selector, selectors);
    if (elements.length === 0) return;

    const key = `${selector || selectors}_${eventName}`;

    // حذف قبلی اگه وجود داشت
    if (_eventListeners.has(key)) {
        RemoveEventListener(selector, selectors, eventName);
    }

    const handler = (e) => {
        const target = e.target;
        const targetSelector = selector || selectors;

        dotNetHelper.invokeMethodAsync('OnEventFired', eventName, targetSelector);
    };

    elements.forEach(el => {
        el.addEventListener(eventName, handler);
    });

    _eventListeners.set(key, { elements, eventName, handler });
}

export function RemoveEventListener(selector, selectors, eventName) {
    const key = `${selector || selectors}_${eventName}`;
    const stored = _eventListeners.get(key);
    if (!stored) return;

    const { elements, handler } = stored;
    elements.forEach(el => {
        el.removeEventListener(eventName, handler);
    });

    _eventListeners.delete(key);
}
