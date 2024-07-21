function handleStudentCardClick(event, studentId) {
    if (event.target.tagName === 'BUTTON') {
        return;
    } else {
        redirectToDetail(studentId);
    }
}

function prepareDeleteModal(studentName, studentId) {
    document.getElementById('studentNameToDelete').textContent = studentName;
    document.getElementById('studentIdToDelete').value = studentId;
}

function statusDeleteModal(statusName, statusId) {
    document.getElementById('statusNameToDelete').textContent = statusName;
    document.getElementById('statusIdToDelete').value = statusId;
}

function redirectToDetail(id) {
    window.location.href = `/Detail?id=${id}`;
}

function submitForm(event) {
    event.preventDefault();

    const form = event.target;
    const formData = new FormData(form);

    fetch(form.action, {
        method: form.method,
        body: formData
    })
        .then(response => response.text())
        .then(data => {
            console.log(data);
        });

    return false;
}

document.getElementById("EmploymentStatus_TypeEmployment").addEventListener("change", function () {
    var selectedType = this.value;

    // Скрываем все блоки
    document.getElementById("работает-блок").style.display = "none";
    document.getElementById("самозанятый-блок").style.display = "none";
    document.getElementById("проходить_службу_в_ВС-блок").style.display = "none";

    // Показываем нужный блок
    if (selectedType === "0") {
        document.getElementById("работает-блок").style.display = "block";
    } else if (selectedType === "1") {
        document.getElementById("самозанятый-блок").style.display = "block";
    } else if (selectedType === "3") {
        document.getElementById("проходить_службу_в_ВС-блок").style.display = "block";
    }
});