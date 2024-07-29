class ProjectAddEdit {
    constructor() {
        this._init();

        this.contractType = null;
    }

    _init() {
        // contract
        this._contractSelectEventListener();
    }

    _contractSelectEventListener = () => {
        // Contract type select.
        const contractTypeSelect = document.getElementById('contract-type');
        if (contractTypeSelect) {
            contractTypeSelect.addEventListener('change', (e) => {
                if (!e || !e.target || !e.target.value)
                    return;
                e.preventDefault();
                this.contractType = e.target.value * 1;
                this._contractAmountControlsSwitch();
            });
        }

        // Presenter Percentage control.
        const presenterSharePercentInput = document.getElementById('presenter-percent');
        if (presenterSharePercentInput) {
            ['keyup', 'change'].forEach((evt) => {
                presenterSharePercentInput.addEventListener(evt, (e) => {
                    e.preventDefault();
                    // Validation presenter share percent.
                    if (!e.target.value)
                        return;
                    if (e.target.value < 1)
                        e.target.value = 1;
                    if (e.target.value > 99)
                        e.target.value = 99;
                    // Set percent to range input.
                    const sharePercentRange = document.getElementById('share-percent-range');
                    sharePercentRange.value = e.target.value;
                    // Set owner share percent to label.
                    const ownerShare = document.getElementById('owner-percent');
                    ownerShare.innerText = 100 - e.target.value;
                });
            })
        }

        // Range input
        const sharePercentRange = document.getElementById('share-percent-range');
        if (sharePercentRange) {
            sharePercentRange.addEventListener('input', (e) => {
                // Set presenter share percentage.
                const ownerSharePercentInput = document.getElementById('presenter-percent');
                ownerSharePercentInput.value = e.target.value;
                // Set owner share percentage to label.
                const ownerShare = document.getElementById('owner-percent');
                ownerShare.innerText = 100 - e.target.value;

            });
        }
    }
    _contractAmountControlsSwitch() {
        if (this.contractType === null)
            return;
        const contractAmountForm = document.getElementById('contract-amount-form');
        if (!contractAmountForm) {
            console.error("Contract amount control not found!");
            return;
        }
        // Hide all controls.
        this._contractHideAndNullAllControls();
        switch (this.contractType) {
            // پروژه شخصی
            case 0:
                break;
            // مقطوع
            case 5:
                this._setDisplayStyleById('amount-control', 'block');
                break;
            // درصدی
            case 10:
                this._setDisplayStyleById('percentage-control', 'block');
                break;
            // دستمزدی
            case 15:
                this._setDisplayStyleById('wages-control', 'block');
                break;
            // فهرست بهایی
            case 20:
                break;
        }
    }
    _contractHideAndNullAllControls() {
        this._setDisplayStyleById('amount-control', 'none');
        this._setDisplayStyleById('wages-control', 'none');
        this._setDisplayStyleById('percentage-control', 'none');
    }

    _setDisplayStyleById(elementId, display) {
        const findElement = document.getElementById(elementId);
        if (!findElement) {
            console.error(`Element not found in DOM by id: '${elementId}'.`);
            return;
        }
        findElement.style.display = display;
    }
}

var projectAddEdit = new ProjectAddEdit();