function scrollToDiv() {
    var element = document.getElementById("bb");
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}
