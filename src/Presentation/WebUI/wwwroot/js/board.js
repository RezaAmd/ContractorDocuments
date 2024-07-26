var board = {};
board = {
    props: {
        stageId: null,
        materials: []
    },
    methods: {
        // material
        prepareMaterialSelectInput: async () => {
            //materialProvider.setupTreeInputs();
        },
        // stage material
        loadMaterialModal: () => {
            if (!board.props.stageId) {
                console.error('construction stage id not found!');
                return;
            }
            board.props.stageId = board.props.stageId;
            const materialModal = new bootstrap.Modal(document.getElementById('supplies-card-modal'))
            materialModal.show();
            board.methods.loadMaterialModalData(board.props.stageId);
        },
        loadMaterialModalData: async (stageId) => {
            if (!stageId)
                return;
            const materialTableBody = document.getElementById('material-table-body');
            materialTableBody.innerHTML = '';

            await rest.getAsync('/admin/project/getStageMaterials',
                { stageId: stageId }, (isSuccess, response) => {
                    if (response) {
                        response.forEach((material) => {
                            materialTableBody.innerHTML += `<tr><td>-</td><td>${material.name}</td>
                            <td>${separateMoney(material.amount)}</td>
                            <td>${separateMoney(material.unitPrice)}</td>
                            <td>${separateMoney(material.amount * material.unitPrice)}</td>
                            <td>${separateMoney(material.totalNetProfit)}</td>
                            </tr>`
                        });
                    }
                })
        },
        addStageMaterial: async () => {
            // prepare stage material data.
            const newSypplyForm = document.getElementById('new-supply');
            const materialSelect = newSypplyForm.querySelectorAll('select[name="MaterialId"]');
            const materialId = materialSelect[materialSelect.length - 1].value;
            const amount = newSypplyForm.querySelector('input[name="Amount"]').value;
            const unitPrice = newSypplyForm.querySelector('input[name="UnitPrice"]').value;
            const totalNetProfit = newSypplyForm.querySelector('input[name="TotalNetProfit"]').value;
            const stageMaterialData = {
                stageId: board.props.stageId,
                MaterialId: materialId,
                Amount: amount,
                UnitPrice: unitPrice,
                TotalNetProfit: totalNetProfit
            }
            await rest.postAsync('/admin/project/addStageMaterial',
                null, stageMaterialData,
                (isSuccess, response) => {
                    debugger
                    if (isSuccess == true) {
                        board.methods.loadMaterialModal();
                    }
                });
        }
    },
    events: {
        materialModalEventTrigger: () => {
            var materialsListItems = document.querySelectorAll('.material-list-item');
            materialsListItems.forEach((materialItem) => {
                // click event on material item.
                materialItem.addEventListener('click', (e) => {
                    board.props.stageId = materialItem.getAttribute('data-stage-id');
                    board.methods.loadMaterialModal();
                });
            });
        },
        addStageMaterialEventListener: () => {
            const addBtn = document.getElementById('add-new-stage-material-btn');
            if (!addBtn)
                return;
            addBtn.addEventListener('click', async () => {
                await board.methods.addStageMaterial();
            });
        }
    },
    init: () => {
        // Prepare material modal event.
        board.events.materialModalEventTrigger();
        board.events.addStageMaterialEventListener();

        // Setup material input.
        materialProvider.setupTreeInputs('material-select-placement');

    }
}