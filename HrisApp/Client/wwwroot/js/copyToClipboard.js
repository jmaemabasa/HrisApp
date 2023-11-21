window.copyToClipboard = function (text) {
    navigator.clipboard.writeText(text)
        .then(function () {
            console.log('Text copied to clipboard: ' + text);
        })
        .catch(function (error) {
            console.error('Error copying text to clipboard: ' + error);
        });
};