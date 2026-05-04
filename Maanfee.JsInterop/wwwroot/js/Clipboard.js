/*
 * JavaScript Clipboard Library 1.0.0
 *
 *
 *
 * Date: 05-02-14 | 03-05-2026
 */

(function (window) {
    'use strict';

    class ClipboardManager {
        constructor() {
            this.supported = this.isClipboardApiSupported();
        }

        // بررسی پشتیبانی از Clipboard API
        isClipboardApiSupported() {
            return !!(
                navigator.clipboard &&
                navigator.clipboard.writeText &&
                navigator.clipboard.readText
            );
        }

        // نوشتن متن در کلیپ‌بورد
        async writeText(text) {
            try {
                if (this.supported) {
                    await navigator.clipboard.writeText(text);
                    return true;
                } else {
                    return await this.fallbackCopyText(text);
                }
            } catch (err) {
                console.error('Failed to write text: ', err);
                return false;
            }
        }

        // خواندن متن از کلیپ‌بورد
        async readText() {
            try {
                if (!this.supported) {
                    throw new Error('Clipboard API not supported');
                }

                const text = await navigator.clipboard.readText();
                return text;
            } catch (err) {
                console.error('Failed to read text: ', err);
                return '';
            }
        }

        // روش جایگزین برای کپی متن (با استفاده از execCommand)
        fallbackCopyText(text) {
            return new Promise((resolve) => {
                try {
                    const textarea = document.createElement('textarea');
                    textarea.value = text;
                    textarea.style.position = 'fixed';
                    textarea.style.top = '0';
                    textarea.style.left = '0';
                    textarea.style.opacity = '0';
                    document.body.appendChild(textarea);

                    textarea.select();
                    textarea.setSelectionRange(0, 99999);

                    const success = document.execCommand('copy');
                    document.body.removeChild(textarea);

                    resolve(success);
                } catch (err) {
                    console.error('Fallback copy failed: ', err);
                    resolve(false);
                }
            });
        }
               
        // نوشتن HTML در کلیپ‌بورد
        async writeHtml(html) {
            try {
                if (!this.supported) {
                    throw new Error('Clipboard API not supported');
                }

                const blob = new Blob([html], { type: 'text/html' });
                const clipboardItem = new ClipboardItem({
                    'text/html': blob,
                    'text/plain': new Blob([this.stripHtml(html)], { type: 'text/plain' })
                });

                await navigator.clipboard.write([clipboardItem]);
                return true;
            } catch (err) {
                console.error('Failed to write HTML: ', err);
                return false;
            }
        }

        // حذف تگ‌های HTML
        stripHtml(html) {
            const tmp = document.createElement('div');
            tmp.innerHTML = html;
            return tmp.textContent || tmp.innerText || '';
        }

        // پاک کردن کلیپ‌بورد
        async clear() {
            try {
                if (this.supported) {
                    await navigator.clipboard.writeText('');
                    return true;
                }
                return false;
            } catch (err) {
                console.error('Failed to clear clipboard: ', err);
                return false;
            }
        }

        // بررسی پشتیبانی
        isSupported() {
            return this.supported;
        }

        // dispose
        dispose() {
            console.log('Clipboard manager disposed');
        }
    }

    // ایجاد نمونه و اتصال به window
    const clipboardManager = new ClipboardManager();

    // تعریف توابع برای فراخوانی از C#
    window.Maanfee = window.Maanfee || {};
    window.Maanfee.JsInterop = window.Maanfee.JsInterop || {};

    window.Maanfee.JsInterop.Clipboard = {
        writeText: (text) => clipboardManager.writeText(text),
        readText: () => clipboardManager.readText(),
        isSupported: () => clipboardManager.isSupported(),
        writeHtml: (html) => clipboardManager.writeHtml(html),
        clear: () => clipboardManager.clear(),
        dispose: () => clipboardManager.dispose()
    };

})(window);

// در صورت نیاز به ماژول ES6
export const writeText = (text) => window.Maanfee.JsInterop.Clipboard.writeText(text);
export const readText = () => window.Maanfee.JsInterop.Clipboard.readText();
export const isSupported = () => window.Maanfee.JsInterop.Clipboard.isSupported();
export const writeHtml = (html) => window.Maanfee.JsInterop.Clipboard.writeHtml(html);
export const clear = () => window.Maanfee.JsInterop.Clipboard.clear();
export const dispose = () => window.Maanfee.JsInterop.Clipboard.dispose();
