﻿document.addEventListener('DOMContentLoaded', async () => {

    //#region Signout controller

    let signOutController = document.querySelectorAll('.sign-out-controller');
    if (signOutController && signOutController.length > 0) {
        signOutController.forEach((controller) => {
            controller.addEventListener('click', async (e) => {
                e.preventDefault();
                await rest.postAsync('/authentication/logout', null, null, (isSuceess, response) => {
                    if (isSuceess === false)
                        alert("درخواست خروج با خطا مواجه شد لطفا بعدا تلاش کنید.");
                    if (response && response.returnUrl)
                        location.href = response.returnUrl;
                    location.href = "/";
                });
            });
        });
    }

    //#endregion

    //#region dark theme

    prepareBootstrapTooltip();

    //#endregion

    
});

const prepareBootstrapTooltip = () => {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-title]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
}

const separateMoney = (Number) => {
    Number += '';
    Number = Number.replace(',', '');
    x = Number.split('.');
    y = x[0];
    z = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(y))
        y = y.replace(rgx, '$1' + ',' + '$2');
    return y + z;
}
