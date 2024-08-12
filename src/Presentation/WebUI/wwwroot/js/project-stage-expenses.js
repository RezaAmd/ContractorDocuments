class ProjecStageExpenses {
    constructor() {
        this._prepareMainModal();
    }

    _prepareMainModal = () => {
        this.mainModalElement = document.getElementById('expenses-card-modal')
        if (this.mainModalElement) {
            this.mainModal = new bootstrap.Modal(this.mainModalElement);
        }

        this.addModalElement = document.getElementById('add-expenses-card-modal')
        if (this.mainModalElement) {
            this.mainModal = new bootstrap.Modal(this.mainModalElement);
        }
    }
    _prepareEventListeners = () => {

    }
    _fetchTableList = async () => {
        await rest.getAsync('/admin/project/getExpenses', null, (isSuccess, response) => {
            debugger
            if (isSuccess) {
                this.list = response.data;
                this._fetchTableListHandler();
            }
        });
    }
    _renderTableList = () => {
        debugger
    }
}