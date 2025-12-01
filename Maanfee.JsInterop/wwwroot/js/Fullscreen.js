/*
 * JavaScript Screen Library V 2.0.0
 *
 *
 *
 * Date: 02-01-31
 */

export function requestFullscreen(elementId = null) {
    let element;

    if (elementId) {
        element = document.getElementById(elementId);
    } else {
        element = document.documentElement;
    }

    if (!element) {
        console.error('Element not found:', elementId);
        return;
    }

    if (element.requestFullscreen) {
        element.requestFullscreen();
    } else if (element.webkitRequestFullscreen) {
        element.webkitRequestFullscreen();
    } else if (element.msRequestFullscreen) {
        element.msRequestFullscreen();
    }
}

export function exitFullscreen() {
    if (document.exitFullscreen) {
        document.exitFullscreen();
    } else if (document.webkitExitFullscreen) {
        document.webkitExitFullscreen();
    } else if (document.msExitFullscreen) {
        document.msExitFullscreen();
    }
}

export function toggleFullscreen(elementId = null) {
    if (isFullscreen()) {
        exitFullscreen();
    } else {
        requestFullscreen(elementId);
    }
}

export function isFullscreen() {
    return !!(document.fullscreenElement ||
        document.webkitFullscreenElement ||
        document.msFullscreenElement);
}

export function getFullscreenElement() {
    const element = document.fullscreenElement ||
        document.webkitFullscreenElement ||
        document.msFullscreenElement;
    return element ? element.id : null;
}

// Events
let fullscreenChangeHandler = null;

export function addFullscreenChangeListener(dotNetHelper) {
    fullscreenChangeHandler = () => {
        const isFullscreenMode = isFullscreen();
        dotNetHelper.invokeMethodAsync('OnFullscreenChange', isFullscreenMode);
    };

    document.addEventListener('fullscreenchange', fullscreenChangeHandler);
    document.addEventListener('webkitfullscreenchange', fullscreenChangeHandler);
    document.addEventListener('msfullscreenchange', fullscreenChangeHandler);
}

export function removeFullscreenChangeListener() {
    if (fullscreenChangeHandler) {
        document.removeEventListener('fullscreenchange', fullscreenChangeHandler);
        document.removeEventListener('webkitfullscreenchange', fullscreenChangeHandler);
        document.removeEventListener('msfullscreenchange', fullscreenChangeHandler);
        fullscreenChangeHandler = null;
    }
}

export function dispose() {
    removeFullscreenChangeListener();
}
