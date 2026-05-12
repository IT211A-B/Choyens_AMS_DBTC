<script>

let editingRow = null;

function openAddModal(){

    document.getElementById("studentModal").style.display = "flex";

    document.getElementById("modalTitle").innerText = "Add Student";

    clearForm();
}

function closeModal(){

    document.getElementById("studentModal").style.display = "none";

}

function clearForm(){

    document.getElementById("studentId").value = "";
    document.getElementById("studentName").value = "";
    document.getElementById("courseYear").value = "";
    document.getElementById("subjectCode").value = "";
    document.getElementById("date").value = "";
    document.getElementById("status").value = "Present";

}

function saveStudent(){

    let id = document.getElementById("studentId").value;
    let name = document.getElementById("studentName").value;
    let course = document.getElementById("courseYear").value;
    let subject = document.getElementById("subjectCode").value;
    let date = document.getElementById("date").value;
    let status = document.getElementById("status").value;

    if(id === "" || name === ""){

        alert("Please fill all fields!");
        return;

    }

    let statusClass =
        status === "Present"
        ? "present-status"
        : "absent-status";

    if(editingRow){

        editingRow.cells[0].innerText = id;
        editingRow.cells[1].innerText = name;
        editingRow.cells[2].innerText = course;
        editingRow.cells[3].innerText = subject;
        editingRow.cells[4].innerText = date;

        editingRow.cells[5].innerHTML =
        `<span class="status ${statusClass}">
            ${status}
        </span>`;

        editingRow = null;

    }else{

        let table = document.getElementById("studentTable");

        let row = table.insertRow();

        row.innerHTML = `

            <td>${id}</td>
            <td>${name}</td>
            <td>${course}</td>
            <td>${subject}</td>
            <td>${date}</td>

            <td>
                <span class="status ${statusClass}">
                    ${status}
                </span>
            </td>

            <td class="actions">

                <i class="fa-solid fa-eye view"
                   onclick="viewStudent(this)"></i>

                <i class="fa-solid fa-pen-to-square edit"
                   onclick="editStudent(this)"></i>

                <i class="fa-solid fa-trash delete"
                   onclick="deleteStudent(this)"></i>

            </td>

        `;

    }

    updateCounts();

    closeModal();

}

function deleteStudent(button){

    if(confirm("Delete this student?")){

        let row = button.parentElement.parentElement;

        row.remove();

        updateCounts();

    }

}

function viewStudent(button){

    let row = button.parentElement.parentElement;

    let data = `
Student ID: ${row.cells[0].innerText}
Name: ${row.cells[1].innerText}
Course: ${row.cells[2].innerText}
Subject: ${row.cells[3].innerText}
Date: ${row.cells[4].innerText}
Status: ${row.cells[5].innerText}
    `;

    alert(data);

}

function editStudent(button){

    editingRow = button.parentElement.parentElement;

    document.getElementById("studentId").value =
    editingRow.cells[0].innerText;

    document.getElementById("studentName").value =
    editingRow.cells[1].innerText;

    document.getElementById("courseYear").value =
    editingRow.cells[2].innerText;

    document.getElementById("subjectCode").value =
    editingRow.cells[3].innerText;

    document.getElementById("date").value =
    editingRow.cells[4].innerText;

    document.getElementById("status").value =
    editingRow.cells[5].innerText.trim();

    document.getElementById("modalTitle").innerText =
    "Edit Student";

    document.getElementById("studentModal").style.display =
    "flex";

}

function searchStudent(){

    let input =
    document.getElementById("searchInput").value.toLowerCase();

    let rows =
    document.querySelectorAll("#studentTable tr");

    rows.forEach(row => {

        let text =
        row.innerText.toLowerCase();

        row.style.display =
        text.includes(input)
        ? ""
        : "none";

    });

}

function updateCounts(){

    let rows =
    document.querySelectorAll("#studentTable tr");

    let total = rows.length;

    let present = 0;
    let absent = 0;

    rows.forEach(row => {

        let status =
        row.cells[5].innerText.trim();

        if(status === "Present"){
            present++;
        }else{
            absent++;
        }

    });

    document.getElementById("totalRecords").innerText =
    total;

    document.getElementById("presentCount").innerText =
    present;

    document.getElementById("absentCount").innerText =
    absent;

}

</script>