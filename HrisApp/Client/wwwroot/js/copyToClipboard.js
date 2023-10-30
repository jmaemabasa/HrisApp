window.copyToClipboard = function (text) {
    navigator.clipboard.writeText(text).then(function () {
        // Text successfully copied to clipboard
        // You can add a notification or perform other actions here
        console.log('Text copied to clipboard: ' + text);
    }).catch(function (error) {
        // Handle any errors
        console.error('Error copying text to clipboard: ' + error);
    });
}