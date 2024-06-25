range2.addEventListener('change', (e) => {
    let value = e.target.value;
    const presenter = document.getElementById('presenter-percent')
    presenter.innerText = value + '%'
    const owner = document.getElementById('owner-percent')
    owner.innerText = 100 - value + '%'
})