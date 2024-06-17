document.addEventListener('DOMContentLoaded', async () => {

    // #region Signout controller

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

});