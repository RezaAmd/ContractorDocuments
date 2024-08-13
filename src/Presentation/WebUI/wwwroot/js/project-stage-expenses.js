class ProjecStageExpenses {
    constructor() {
        this._prepareMainModal();
        this._prepareEventListeners();
    }

    projectStageId = null;
    mainModal = null;
    mainModalElement = null;
    addModalElement = null;
    addExpensesBtn = null;

    _pendingAddExpensesButton = () => {
        if (!this.addExpensesBtn)
            return;
        this.addExpensesBtn.setAttribute('disabled', 'disabled');
        // Show spinner
        const spinner = this.addExpensesBtn.querySelector('.spinner-border');
        if (!spinner)
            return;
        spinner.style.display = 'inline-block';
    }
    _readyAddExpensesButton = () => {
        if (!this.addExpensesBtn)
            return;
        this.addExpensesBtn.removeAttribute('disabled');
        // Show spinner
        const spinner = this.addExpensesBtn.querySelector('.spinner-border');
        if (!spinner)
            return;
        spinner.style.display = 'none';
    }
    // Prepare new expenses form data and validation.
    _prepareNewExpensesAndValidation = () => {
        this.newExpenses = {
            projectStageId: this.projectStageId
        };
        // Prepare form data.
        const titleInput = this.addModalElement.querySelector('input[name="Title"]');
        if (!titleInput) {
            console.error('Expenses title was not found!');
            return;
        }
        this.newExpenses.title = titleInput.value;

        const amountInput = this.addModalElement.querySelector('input[name="Amount"]');
        if (!amountInput) {
            console.error('Expenses amount was not found!');
            return;
        }
        this.newExpenses.amount = amountInput.value;

        const painOnInput = this.addModalElement.querySelector('input[name="PaidOn"]');
        if (!painOnInput) {
            console.error('Expenses amount was not found!');
            return;
        }
        this.newExpenses.paidOn = painOnInput.value;

        const descriptionInput = this.addModalElement.querySelector('textarea[name="Description"]');
        if (!descriptionInput) {
            console.error('Expenses amount was not found!');
            return;
        }
        this.newExpenses.description = descriptionInput.value;
        // Validation form data.
        if (!this.newExpenses.title) {
            titleInput.focus();
            return;
        }
        if (!this.newExpenses.amount || this.newExpenses.amount <= 0) {
            amountInput.focus();
            amountInput.select();
            return;
        }
        if (!this.newExpenses.paidOn) {
            painOnInput.focus();
            return;
        }

        return true;
    }
    _resetNewExpenseForm = () => {
        // Prepare form data.
        const titleInput = this.addModalElement.querySelector('input[name="Title"]');
        if (titleInput) {
            titleInput.value = '';
        }

        const amountInput = this.addModalElement.querySelector('input[name="Amount"]');
        if (amountInput) {
            amountInput.value = '';
        }

        const painOnInput = this.addModalElement.querySelector('input[name="PaidOn"]');
        if (painOnInput) {
            painOnInput.value = '';
        }

        const descriptionInput = this.addModalElement.querySelector('textarea[name="Description"]');
        if (descriptionInput) {
            descriptionInput.value = '';
        }
    }
    _sendNewExpenses = async () => {
        // Prepare and validation data.
        const validationResult = this._prepareNewExpensesAndValidation();
        if (!validationResult || validationResult == false)
            return;
        // Lock add button.
        this._pendingAddExpensesButton();
        // Send form data to api.
        await rest.postAsync('/admin/project/addStageExpenses', null, this.newExpenses,
            (isSuccess, response) => {
                // Unlock
                this._readyAddExpensesButton();
                if (isSuccess && isSuccess == true) {
                    // Reset form
                    this._resetNewExpenseForm();
                    // Close modal.
                    this.addModal.hide();
                }
            });
    }
    _prepareMainModal = () => {
        // prepare Main modal.
        this.mainModalElement = document.getElementById('expenses-card-modal')
        if (this.mainModalElement) {
            this.mainModal = new bootstrap.Modal(this.mainModalElement);
        }
        // Prepare add modal
        this.addModalElement = document.getElementById('add-expenses-card-modal')
        if (this.addModalElement) {
            this.addModal = new bootstrap.Modal(this.addModalElement);
        }
    }
    _prepareEventListeners = () => {
        // Main modal events
        if (this.mainModalElement) {
            this.mainModalElement.addEventListener('shown.bs.modal', async () => {
                // Load expenses data.
                await this._fetchTableList();
            });
            this.mainModalElement.addEventListener('hidden.bs.modal', () => {
                // Load expenses data.
                const tableBody = document.getElementById('expense-table-body');
                if (!tableBody) {
                    console.error('Expense table body was not found!');
                    return;
                }
                tableBody.innerHTML = '<tr><td class="text-center" colspan="6">درحال بارگیری ...</td><tr>';
            });
        }
        if (this.addModalElement) {
            this.addModalElement.addEventListener('hidden.bs.modal', () => {
                this.mainModal.show();
            })
        }
        // Project stage id
        const expensesListItems = document.querySelectorAll('.expenses-list-item');
        if (expensesListItems) {
            expensesListItems.forEach((expensesItem) => {
                // click event on material item.
                expensesItem.addEventListener('click', (e) => {
                    this.projectStageId = expensesItem.getAttribute('data-stage-id');
                });
            });
        }
        // Add expenses modal event.
        const addExpenseModalBtn = document.getElementById('add-expense-modal-btn');
        if (addExpenseModalBtn) {
            addExpenseModalBtn.addEventListener('click', (e) => {
                e.preventDefault();
                this.mainModal.hide();
                this.addModal.show();
            });
        }
        // Add expenses form button event.
        this.addExpensesBtn = document.getElementById('add-expenses-btn');
        if (this.addExpensesBtn) {
            this.addExpensesBtn.addEventListener('click', () => {
                this._sendNewExpenses();
            });
        }
    }
    _fetchTableList = async () => {
        await rest.getAsync('/admin/project/getStageExpenses',
            {
                stageId: `${this.projectStageId}`
            }, (isSuccess, response) => {

                if (isSuccess) {
                    this.list = response;
                    // Render table list data.
                    this._renderTableList();
                }
            });
    }
    _renderTableList = () => {
        const tableBody = document.getElementById('expense-table-body');
        if (!tableBody) {
            console.error('Expense table body was not found!');
            return;
        }
        tableBody.innerHTML = '';
        if (!this.list || this.list.length <= 0) {
            tableBody.innerHTML = '<tr><td colspan="5" class="small text-center">موردی یافت نشد.</td></tr>';
            return;
        }
        this.list.forEach((expense) => {
            tableBody.innerHTML += `
            <tr>
            <td>${expense.title}</td>
            <td>${separateMoney(expense.amount)}</td>
            <td>${expense.paidOn}</td>
            <td>${expense.description}</td>
            <td>
              <div class="dropdown dropend">
                <a class="btn btn-sm btn-light dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" ariaexpanded="false">
                  بیشتر
                </a>
                <ul class="dropdown-menu">
                  <li>
                  <a class="dropdown-item" href="#">حذف</a>
                  </li>
                  <li>
                  <a class="dropdown-item" href="#">جابجا کردن</a>
                  </li>
                </ul>
              </div>
              </td>
            </tr>`;
        });
    }
}