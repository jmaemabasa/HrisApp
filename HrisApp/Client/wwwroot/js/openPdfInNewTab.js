function openPdfInNewTab(verid) {
    // Open a new tab/window
    var pdfUrl = "https://localhost:44350/api/Report/GetReport?verid="+verid;
    var newTab = window.open('', '_blank');

    // Set the content of the new tab to an HTML page containing the PDF file
    newTab.document.write('<html><head><title>PDF Viewer</title></head><body style="margin:0;"><iframe width="100%" height="100%" src="' + pdfUrl + '"></iframe></body></html>');
    newTab.document.close();
}
