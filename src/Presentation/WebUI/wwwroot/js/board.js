var board = {};
board = {
    props: {
        projectId: null,
        stageId: null,
        materials: [],
        stageSupplyModal: null,
        removeStageMaterialModal: null,
        transferMaterialModal: null,
        materialRemoveId: null
    },
    methods: {
        prepareProjectProperties: () => {
            const projectIdInput = document.getElementById('project-id');
            if (projectIdInput)
                board.props.projectId = projectIdInput.value;
            // Prepare remove material modal.
            const removeMaterialModal = document.getElementById('remove-material-modal');
            if (removeMaterialModal)
                board.props.removeStageMaterialModal = new bootstrap.Modal(removeMaterialModal);
            // Prepare transfer material modal.
            const transferMaterialModal = document.getElementById('transfer-material-modal');
            if (transferMaterialModal)
                board.props.transferMaterialModal = new bootstrap.Modal(transferMaterialModal);
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
            board.props.stageSupplyModal = new bootstrap.Modal(document.getElementById('supplies-card-modal'))
            board.props.stageSupplyModal.show();
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
                            <td>
                            <div class="dropdown dropend">
                              <a class="btn btn-sm btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                بیشتر
                              </a>
                              <ul class="dropdown-menu">
                                <li onClick="board.events.removeSupplyItemClickEventListener('${material.id}')">
                                <a class="dropdown-item" href="#">حذف</a>
                                </li>
                                <li onClick="board.events.changeSupplyStageItemClickEventListener()">
                                <a class="dropdown-item" href="#">جابجا کردن</a>
                                </li>
                              </ul>
                            </div>
                            </td>
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
                        board.methods._cleanNewMaterialForm();
                    }
                });
        },
        _cleanNewMaterialForm: () => {
            const newSupplyForm = document.getElementById('new-supply');
            if (!newSupplyForm) {
                console.error('New supply form was not found!');
                return;
            }
            newSupplyForm.querySelector('input[name="Amount"]').value = '';
            newSupplyForm.querySelector('input[name="UnitPrice"]').value = '';
            newSupplyForm.querySelector('input[name="PurchasedOn"]').value = '';
            newSupplyForm.querySelector('input[name="TransportCost"]').value = '';
            newSupplyForm.querySelector('input[name="TotalNetProfit"]').value = '';
        },
        removeStageMaterial: async (id) => {
            debugger
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
        // Project location events.
        projectLocationEventListeners: () => {
            const projectLocationModal = document.getElementById('project-location-modal');
            if (projectLocationModal) {
                projectLocationModal.addEventListener('shown.bs.modal', () => {
                    debugger
                });
            }
        },
        materialModalEventTrigger: () => {
            var materialsListItems = document.querySelectorAll('.material-list-item');
            materialsListItems.forEach((materialItem) => {
                // click event on material item.
                materialItem.addEventListener('click', (e) => {
                    board.props.stageId = materialItem.getAttribute('data-stage-id');
                    board.methods.loadMaterialModal();
                });
            });
            // Remove material confirm button
            const materialRemoveConfirmBtn = document.getElementById('remove-stage-material-btn');
            if (materialRemoveConfirmBtn) {
                materialRemoveConfirmBtn.addEventListener('click', async (e) => {
                    if (!board.props.materialRemoveId) {
                        console.error("Material id was not found!");
                        return;
                    }
                    await rest.getAsync('/admin/project/deleteMaterial?id=' + board.props.materialRemoveId, null,
                        (isSuccess, response) => {
                            board.props.removeStageMaterialModal.hide();
                            board.methods.loadMaterialModal();
                        });
                });
            }

            const removeMaterialModal = document.getElementById('remove-material-modal');
            if (removeMaterialModal) {
                removeMaterialModal.addEventListener('hidden.bs.modal', () => {
                    board.props.stageSupplyModal.show();
                })
            }
        },
        addStageMaterialEventListener: () => {
            const addBtn = document.getElementById('add-new-stage-material-btn');
            if (!addBtn)
                return;
            addBtn.addEventListener('click', async () => {
                await board.methods.addStageMaterial();
            });
        },
        removeSupplyItemClickEventListener: (id) => {
            if (!id) {
                console.error('Material id not found!');
                return;
            }
            board.props.materialRemoveId = id;
            board.props.stageSupplyModal.hide();
            board.props.removeStageMaterialModal.show();
        },
        changeSupplyStageItemClickEventListener: () => {
            debugger
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
        board.events.projectLocationEventListeners();
        // Setup material input.
        materialProvider.setupTreeInputs('material-select-placement');
        // Load page when modal closed.
        const modals = document.querySelectorAll('.modal');
        modals.forEach((modal) => {
            modal.addEventListener('hide.bs.modal', () => {
                //window.location.reload();
            })
        });

        // Prepare expenses
        board.props.expenses = new ProjecStageExpenses();

        // Money Split
        const moneyElements = document.querySelectorAll('[data-money]');
        moneyElements.forEach((moneyElement) => {
            moneyElement.innerHTML = separateMoney(moneyElement.getAttribute('data-money'));
        });
    }
}