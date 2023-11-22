function themeToggle(isDarkMode) {
    const stylesheet = document.getElementById('theme-stylesheet');
    if (isDarkMode) {
        stylesheet.href = 'css/styles-dark.css';
    } else {
        stylesheet.href = 'css/styles-light.css';
    }
};