/*
 * JavaScript Print Library 0.0.0
 *
 *
 *
 * Date: 04-09-11
 */

export function printElement(elementId) {
    const originalContent = document.body.innerHTML;
    const elementContent = document.getElementById(elementId).innerHTML;

    document.body.innerHTML = elementContent;
    window.print();
    document.body.innerHTML = originalContent;
}

export function print(id) {
    const element = document.getElementById(id);
    if (!element) return;

    // کپی عمیق از المان با حفظ استایل‌ها
    const elementClone = element.cloneNode(true);

    // ایجاد iframe
    const iframe = document.createElement("iframe");
    iframe.style.cssText = `
        position: fixed;
        width: 0;
        height: 0;
        border: 0;
        visibility: hidden;
    `;
    document.body.appendChild(iframe);

    const doc = iframe.contentWindow.document;

    // جمع‌آوری تمام استایل‌های صفحه
    const allStyles = [];

    // استایل‌های لینک شده
    document.querySelectorAll('link[rel="stylesheet"]').forEach(link => {
        allStyles.push(`<link rel="stylesheet" href="${link.href}">`);
    });

    // استایل‌های داخلی
    document.querySelectorAll('style').forEach(style => {
        allStyles.push(`<style>${style.textContent}</style>`);
    });

    // HTML نهایی
    const htmlContent = `
        <!DOCTYPE html>
        <html>
        <head>
            <title>Print</title>
            <meta charset="UTF-8">
            <base href="${document.baseURI}">
            ${allStyles.join('')}
            <style>
                /* تضمین چاپ رنگی */
                @media print {
                    * {
                        -webkit-print-color-adjust: exact !important;
                        print-color-adjust: exact !important;
                        color-adjust: exact !important;
                    }
                    
                    body {
                        margin: 0 !important;
                        padding: 20px !important;
                        background: white !important;
                    }
                    
                    table {
                        border-collapse: collapse !important;
                    }
                    
                    th, td {
                        border: 1px solid #000 !important;
                    }
                }
                
            </style>
        </head>
        <body>
            ${elementClone.outerHTML}
        </body>
        </html>
    `;

    doc.open();
    doc.write(htmlContent);
    doc.close();

    // چاپ با تاخیر برای اطمینان از بارگذاری استایل‌ها
    setTimeout(() => {
        try {
            iframe.contentWindow.focus();
            iframe.contentWindow.print();

            // پاکسازی iframe بعد از چاپ
            iframe.contentWindow.onafterprint = () => {
                setTimeout(() => {
                    if (iframe.parentNode) {
                        iframe.parentNode.removeChild(iframe);
                    }
                }, 100);
            };
        } catch (error) {
            console.error('خطا در چاپ:', error);
            // پاکسازی iframe در صورت خطا
            if (iframe.parentNode) {
                iframe.parentNode.removeChild(iframe);
            }
        }
    }, 1500);
}
