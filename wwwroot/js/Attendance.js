let editingRow = null;

function openAddModal() {

    editingRow = null;

    document.getElementById("modalTitle").innerText =
        "Add Attendance";

    clearForm();

    document.getElementById("attendanceModal").style.display =
        "flex";
}

function closeModal() {

    document.getElementById("attendanceModal").style.display =
        "none";
}

function clearForm() {

    document.getElementById("studentId").value = "";
    document.getElementById("studentName").value = "";
    document.getElementById("courseYear").value = "";
    document.getElementById("subjectCode").value = "";
    document.getElementById("date").value = "";
    document.getElementById("timeIn").value = "";
    document.getElementById("timeOut").value = "";
    document.getElementById("status").value = "Present";
    document.getElementById("remarks").value = "";
}

function saveAttendance() {

    let studentId =
        document.getElementById("studentId").value;

    let studentName =
        document.getElementById("studentName").value;

    let courseYear =
        document.getElementById("courseYear").value;

    let subjectCode =
        document.getElementById("subjectCode").value;

    let date =
        document.getElementById("date").value;

    let timeIn =
        document.getElementById("timeIn").value;

    let timeOut =
        document.getElementById("timeOut").value;

    let status =
        document.getElementById("status").value;

    let remarks =
        document.getElementById("remarks").value;

    if (
        studentId === "" ||
        studentName === "" ||
        courseYear === "" ||
        subjectCode === "" ||
        date === ""
    ) {
        alert("Please fill in all fields.");
        return;
    }

    let statusClass = "";

    if (status === "Present") {
        statusClass = "present-status";
    }
    else if (status === "Absent") {
        statusClass = "absent-status";
    }
    else {
        statusClass = "late-status";
    }

    if (editingRow == null) {

        let table =
            document.getElementById("attendanceTable");

        let row = table.insertRow();

        row.innerHTML = `
            <td>${studentId}</td>

            <td>
                <strong>${studentName}</strong>
            </td>

            <td>${courseYear}</td>

            <td>${subjectCode}</td>

            <td>${date}</td>

            <td>
                In: ${timeIn} <br>
                Out: ${timeOut}
            </td>

            <td>
                <span class="status ${statusClass}">
                    ${status}
                </span>
            </td>

            <td>${remarks}</td>

            <td class="actions">

                <i class="fa-solid fa-eye view"
                   onclick="viewAttendance(this)"></i>

                <i class="fa-solid fa-pen-to-square edit"
                   onclick="editAttendance(this)"></i>

                <i class="fa-solid fa-trash delete"
                   onclick="deleteAttendance(this)"></i>

            </td>
        `;

    } else {

        editingRow.cells[0].innerText =
            studentId;

        editingRow.cells[1].innerHTML =
            `<strong>${studentName}</strong>`;

        editingRow.cells[2].innerText =
            courseYear;

        editingRow.cells[3].innerText =
            subjectCode;

        editingRow.cells[4].innerText =
            date;

        editingRow.cells[5].innerHTML =
            `In: ${timeIn}<br>Out: ${timeOut}`;

        editingRow.cells[6].innerHTML =
            `<span class="status ${statusClass}">
                ${status}
            </span>`;

        editingRow.cells[7].innerText =
            remarks;
    }

    updateCounts();

    closeModal();
}

function editAttendance(button) {

    editingRow =
        button.parentElement.parentElement;

    document.getElementById("modalTitle").innerText =
        "Edit Attendance";

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

    let timeData =
        editingRow.cells[5].innerText.split("Out:");

    document.getElementById("timeIn").value =
        timeData[0].replace("In:", "").trim();

    document.getElementById("timeOut").value =
        timeData[1].trim();

    document.getElementById("status").value =
        editingRow.cells[6].innerText.trim();

    document.getElementById("remarks").value =
        editingRow.cells[7].innerText;

    document.getElementById("attendanceModal").style.display =
        "flex";
}

function deleteAttendance(button) {

    if (confirm("Delete this attendance?")) {

        let row =
            button.parentElement.parentElement;

        row.remove();

        updateCounts();
    }
}

function viewAttendance(button) {

    let row =
        button.parentElement.parentElement;

    alert(row.innerText);
}

function searchAttendance() {

    let input =
        document.getElementById("searchInput")
            .value
            .toLowerCase();

    let rows =
        document.querySelectorAll("#attendanceTable tr");

    rows.forEach(row => {

        let text =
            row.innerText.toLowerCase();

        row.style.display =
            text.includes(input)
                ? ""
                : "none";
    });
}

function updateCounts() {

    let rows =
        document.querySelectorAll("#attendanceTable tr");

    let present = 0;
    let absent = 0;
    let late = 0;

    rows.forEach(row => {

        let status =
            row.cells[6].innerText.trim();

        if (status === "Present") {
            present++;
        }
        else if (status === "Absent") {
            absent++;
        }
        else {
            late++;
        }
    });

    document.getElementById("totalRecords").innerText =
        rows.length;

    document.getElementById("presentCount").innerText =
        present;

    document.getElementById("absentCount").innerText =
        absent;

    document.getElementById("lateCount").innerText =
        late;

    document.getElementById("footerTotal").innerText =
        rows.length;

    document.getElementById("footerPresent").innerText =
        present;

    document.getElementById("footerAbsent").innerText =
        absent;

    document.getElementById("footerLate").innerText =
        late;
}

window.onclick = function (event) {

    let modal =
        document.getElementById("attendanceModal");

    if (event.target == modal) {
        closeModal();
    }
}