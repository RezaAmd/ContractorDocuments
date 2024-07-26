var materialProvider = {};
materialProvider = {
    _props: {
        placementElement: null,
        materials: []
    },
    _fetchMaterialsData: async () => {
        await rest.getAsync('/admin/material/getAll', null, (isSuccess, response) => {
            materialProvider._props.materials = response;
            materialProvider._prepareSelectInput();
        });
    },
    _prepareSelectInput: () => {
        // find element.
        if (!materialProvider._props.placementElement) {
            console.error('Material placement not found!');
            return;
        }
        // Create select input.
        let selectInput = document.createElement('select');
        selectInput.name = 'MaterialId'
        selectInput.classList.add('form-control');
        selectInput.classList.add('mb-3');
        // Prepare default option.
        const defaultOption = document.createElement('option');
        defaultOption.text = 'انتخاب کنید'
        defaultOption.setAttribute('selected', 'selected');
        defaultOption.setAttribute('disabled', 'disabled');
        selectInput.append(defaultOption);
        // Append materials to select as option.
        materialProvider._props.materials.forEach((material) => {
            // Create select option.
            let selectOption = document.createElement('option');
            selectOption.value = material.id;
            selectOption.text = material.name;
            selectInput.append(selectOption);
        });
        selectInput.addEventListener('change', materialProvider._handleSelectChange);
        const label = document.createElement('label');
        label.textContent = 'نوع مواد';
        label.classList.add('mb-2');
        materialProvider._props.placementElement.appendChild(label);
        // Append to placement element.
        materialProvider._props.placementElement.appendChild(selectInput);
    },
    _handleSelectChange: (e) => {
        const selectedMaterialId = e.target.value;
        // Remove exist input.
        const childMaterialSelect = document.getElementById('material-child-select');
        if (childMaterialSelect) {
            childMaterialSelect.outerHTML = '';
        }
        let findMaterial = materialProvider._props.materials.find(m => m.id == selectedMaterialId);
        if (!findMaterial || findMaterial.children.length == 0)
            return;
        // create select input element.
        const selectInput = document.createElement('select');
        selectInput.name = 'MaterialId'
        selectInput.id = 'material-child-select';
        selectInput.classList.add('form-control');
        selectInput.classList.add('mb-3');
        // Prepare default option.
        const defaultOption = document.createElement('option');
        defaultOption.text = 'انتخاب کنید';
        defaultOption.setAttribute('selected', 'selected');
        defaultOption.setAttribute('disabled', 'disabled');
        selectInput.appendChild(defaultOption);
        // Append material to select as option.
        findMaterial.children.forEach((material) => {
            const option = document.createElement('option');
            option.value = material.id;
            option.text = material.name;
            selectInput.appendChild(option);
        });
        // Append input to placement.
        materialProvider._props.placementElement.appendChild(selectInput);
    },
    setupTreeInputs: (elementId) => {
        materialProvider._props.placementElement = document.getElementById(elementId);
        materialProvider._fetchMaterialsData();
    }
};