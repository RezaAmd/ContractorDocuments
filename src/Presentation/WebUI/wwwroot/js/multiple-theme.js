const clickEventToChangeThemeControllers = () => {
    let themeController = document.querySelectorAll('[data-theme]');
    if (!themeController)
        return;

    themeController.forEach((controller) => {
        // Add click listener to change theme controller.
        controller.addEventListener('click', (e) => {
            e.preventDefault();
            let themeKey = e.currentTarget.getAttribute('data-theme');
            // Set theme to body.
            setTheme(themeKey);
        });
    });
}

const loadThemeFromCache = () => {
    let themeKey = localStorage.getItem('theme');
    if (!themeKey)
        return;
    setTheme(themeKey);
};

const setTheme = (themeKey) => {
    document.body.setAttribute('data-bs-theme', themeKey);
    // Cache theme.
    localStorage.setItem('theme', themeKey);
}

// Load theme from cache.
loadThemeFromCache();
// Add click event
clickEventToChangeThemeControllers();