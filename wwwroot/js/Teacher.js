let editingRow = null;

/* OPEN MODAL */

function openAddModal() {

    editingRow = null;

    document.getElementById("modalTitle").innerText =
        "Add Teacher";

    clearForm();

    document.getElementById("teacherModal").style.display =
        "flex";
}

/* CLOSE MODAL */

function closeModal() {

    document.getElementById("teacherModal").style.display =
        "none";
}

/* CLEAR FORM */

function clearForm() {

    document.getElementById("teacherId").value = "";
    document.getElementById("teacherName").value = "";
    document.getElementById("teacherEmail").value = "";
    document.getElementById("teacherDepartment").value = "";
    document.getElementById("specialization").value = "";
    document.getElementById("specializationDate").value = "";
}

/* SAVE TEACHER */

function saveTeacher() {

    let id =
        document.getElementById("teacherId").value;

    let name =
        document.getElementById("teacherName").value;

    let email =
        document.getElementById("teacherEmail").value;

    let department =
        document.getElementById("teacherDepartment").value;

    let specialization =
        document.getElementById("specialization").value;

    let specializationDate =
        document.getElementById("specializationDate").value;

    if (
        id === "" ||
        name === "" ||
        email === "" ||
        department === "" ||
        specialization === "" ||
        specializationDate === ""
    ) {

        alert("Please fill all fields!");
        return;
    }

    /* EDIT */

    if (editingRow != null) {

        editingRow.cells[0].innerText = id;
        editingRow.cells[1].innerText = name;
        editingRow.cells[2].innerText = email;
        editingRow.cells[3].innerText = department;
        editingRow.cells[4].innerText = specialization;

        editingRow = null;
    }

    /* ADD */

    else {

        let table =
            document.getElementById("teacherTable");

        let row =
            table.insertRow();

        row.innerHTML = `

            <td>${id}</td>

            <td>${name}</td>

            <td>${email}</td>

            <td>${department}</td>

            <td>${specialization}</td>

            <td class="actions">

                <i class="fa-solid fa-eye view"
                   onclick="viewTeacher(this)"></i>

                <i class="fa-solid fa-pen-to-square edit"
                   onclick="editTeacher(this)"></i>

                <i class="fa-solid fa-trash delete"
                   onclick="deleteTeacher(this)"></i>

            </td>
        `;
    }

    updateCounts();

    closeModal();
}

/* DELETE */

function deleteTeacher(button) {

    if (confirm("Delete this teacher?")) {

        let row =
            button.parentElement.parentElement;

        row.remove();

        updateCounts();
    }
}

/* VIEW */

function viewTeacher(button) {

    let row =
        button.parentElement.parentElement;

    let data =

        "Teacher ID: " + row.cells[0].innerText + "\n" +
        "Teacher Name: " + row.cells[1].innerText + "\n" +
        "Email: " + row.cells[2].innerText + "\n" +
        "Department: " + row.cells[3].innerText + "\n" +
        "Specialization: " + row.cells[4].innerText;

    alert(data);
}

/* EDIT */

function editTeacher(button) {

    editingRow =
        button.parentElement.parentElement;

    document.getElementById("teacherId").value =
        editingRow.cells[0].innerText;

    document.getElementById("teacherName").value =
        editingRow.cells[1].innerText;

    document.getElementById("teacherEmail").value =
        editingRow.cells[2].innerText;

    document.getElementById("teacherDepartment").value =
        editingRow.cells[3].innerText;

    document.getElementById("specialization").value =
        editingRow.cells[4].innerText;

    document.getElementById("modalTitle").innerText =
        "Edit Teacher";

    document.getElementById("teacherModal").style.display =
        "flex";
}

/* SEARCH */

function searchTeacher() {

    let input =
        document.getElementById("searchInput")
            .value
            .toLowerCase();

    let rows =
        document.querySelectorAll("#teacherTable tr");

    rows.forEach(row => {

        let text =
            row.innerText.toLowerCase();

        row.style.display =
            text.includes(input)
                ? ""
                : "none";
    });
}

/* UPDATE COUNTS */

function updateCounts() {

    let rows =
        document.querySelectorAll("#teacherTable tr");

    document.getElementById("totalTeachers").innerText =
        rows.length;
}