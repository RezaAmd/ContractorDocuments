var board = {};
board = {
    props: {
        projectId: null,
        stageId: null,
        materials: []
    },
    methods: {
        prepareProjectProperties: () => {
            const projectIdInput = document.getElementById('project-id');
            if (projectIdInput)
                board.props.projectId = projectIdInput.value;
        },
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
                            materialTableBody.innerHTML += `
                            <tr>
                            <td>${material.name}</td>
                            <td>${separateMoney(material.amount)}</td>
                            <td>${separateMoney(material.unitPrice)}</td>
                            <td>${separateMoney(material.transportCost)}</td>
                            <td>${separateMoney(material.totalCost)}</td>
                            <td>${separateMoney(material.totalNetProfit)}</td>
                            <td>${material.purchasedOn ? material.purchasedOn : '-'}</td>
                            </tr>`
                        });
                    }
                })
        },
        addStageMaterial: async () => {
            // prepare stage material data.
            const newSupplyForm = document.getElementById('new-supply');
            if (!newSupplyForm) {
                console.error('New supply form was not found!');
                return;
            }
            const materialSelect = newSupplyForm.querySelectorAll('select[name="MaterialId"]');
            const materialId = materialSelect[materialSelect.length - 1].value;
            if (!materialId) {
                alert('لطفا نوع مصالح را مشخص نمایید.');
                return;
            }
            const amount = newSupplyForm.querySelector('input[name="Amount"]').value;
            if (!amount) {
                alert('لطفا مقدار مواد تهیه شده را مشخص نمایید.');
                return;
            }
            const unitPrice = newSupplyForm.querySelector('input[name="UnitPrice"]').value;
            if (!unitPrice) {
                alert('لطفا قیمت واحد را وارد نمایید..');
                return;
            }

            const purchasedOn = newSupplyForm.querySelector('input[name="PurchasedOn"]').value;
            const transportCost = newSupplyForm.querySelector('input[name="TransportCost"]').value;
            const totalNetProfit = newSupplyForm.querySelector('input[name="TotalNetProfit"]').value;

            const stageMaterialData = {
                StageId: board.props.stageId,
                MaterialId: materialId,
                Amount: amount * 1,
                UnitPrice: unitPrice * 1
            }
            if (purchasedOn)
                stageMaterialData.PurchasedOn = purchasedOn;
            if (transportCost && transportCost > 0)
                stageMaterialData.TransportCost = transportCost * 1;
            if (totalNetProfit && totalNetProfit > 0)
                stageMaterialData.TotalNetProfit = totalNetProfit * 1;

            await rest.postAsync('/admin/project/addStageMaterial',
                null, stageMaterialData,
                (isSuccess, response) => {
                    if (isSuccess == true) {
                        board.methods.loadMaterialModal();
                    }
                });
        },
        // Construction stages
        prepareRemaningStages: async () => {
            await board.methods._fetchRemaningStages();
        },
        _fetchRemaningStages: async () => {
            rest.getAsync('/admin/project/getRemaningStages',
                {
                    projectId: board.props.projectId
                },
                (isSuccess, response) => {
                    board.methods._fetchRemaningStagesHandler(isSuccess, response);
                }
            );
        },
        _fetchRemaningStagesHandler: (isSuccess, response) => {
            if (!isSuccess) {
                console.error("An error has occured on fetching remaning construction stages!");
                return;
            }
            if (!response.data || response.data.length == 0) return;
            // Find stage select input.
            const stageSelectControl = document.getElementById('stages-select-control');
            if (!stageSelectControl) {
                console.error('Stage select input not found!');
                return;
            }
            // Append option to select.
            response.data.forEach((stage) => {
                const stageOption = document.createElement('option');
                stageOption.value = stage.id;
                stageOption.text = stage.name;
                stageSelectControl.appendChild(stageOption);
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
    init: async () => {
        // Prepare project properties.
        board.methods.prepareProjectProperties();
        // Fetch remaning stages.
        board.methods.prepareRemaningStages();
        // Prepare material modal event.
        board.events.materialModalEventTrigger();
        board.events.addStageMaterialEventListener();

        // Setup material input.
        materialProvider.setupTreeInputs('material-select-placement');

        // Load page when modal closed.
        const modals = document.querySelectorAll('.modal');
        modals.forEach((modal) => {
            modal.addEventListener('hide.bs.modal', () => {
                window.location.reload();
            })
        });

        // Money Split
        const moneyElements = document.querySelectorAll('[data-money]');
        moneyElements.forEach((moneyElement) => {
            moneyElement.innerHTML = separateMoney(moneyElement.getAttribute('data-money'));
        });
    }
}