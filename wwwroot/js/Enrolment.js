let editingRow = null;

function openAddModal() {

    editingRow = null;

    document.getElementById("modalTitle").innerText =
        "Add Enrolment";

    clearForm();

    document.getElementById("enrolmentModal").style.display =
        "flex";
}

function closeModal() {
    document.getElementById("enrolmentModal").style.display =
        "none";
}

function clearForm() {

    document.getElementById("studentId").value = "";
    document.getElementById("studentName").value = "";
    document.getElementById("courseCode").value = "";
    document.getElementById("courseName").value = "";
    document.getElementById("yearLevel").value = "";
    document.getElementById("semester").value = "";
    document.getElementById("status").value = "Enrolled";
}

function saveEnrolment() {

    let studentId =
        document.getElementById("studentId").value;

    let studentName =
        document.getElementById("studentName").value;

    let courseCode =
        document.getElementById("courseCode").value;

    let courseName =
        document.getElementById("courseName").value;

    let yearLevel =
        document.getElementById("yearLevel").value;

    let semester =
        document.getElementById("semester").value;

    let status =
        document.getElementById("status").value;

    if (
        studentId === "" ||
        studentName === "" ||
        courseCode === "" ||
        courseName === "" ||
        yearLevel === "" ||
        semester === ""
    ) {
        alert("Please fill in all fields.");
        return;
    }

    let statusClass = "";

    if (status === "Enrolled") {
        statusClass = "enrolled-status";
    }
    else if (status === "Dropped") {
        statusClass = "dropped-status";
    }
    else {
        statusClass = "completed-status";
    }

    if (editingRow == null) {

        let table =
            document.getElementById("enrolmentTable");

        let row = table.insertRow();

        row.innerHTML = `
            <td>E00${table.rows.length}</td>

            <td>
                <strong>${studentName}</strong><br>
                ${studentId}
            </td>

            <td>
                <strong>${courseCode}</strong><br>
                ${courseName}
            </td>

            <td>
                ${yearLevel} - ${semester}
            </td>

            <td>
                <span class="status ${statusClass}">
                    ${status}
                </span>
            </td>

            <td class="actions">

                <i class="fa-solid fa-eye view"
                   onclick="viewEnrolment(this)"></i>

                <i class="fa-solid fa-pen-to-square edit"
                   onclick="editEnrolment(this)"></i>

                <i class="fa-solid fa-trash delete"
                   onclick="deleteEnrolment(this)"></i>

            </td>
        `;

    } else {

        editingRow.cells[1].innerHTML =
            `<strong>${studentName}</strong><br>${studentId}`;

        editingRow.cells[2].innerHTML =
            `<strong>${courseCode}</strong><br>${courseName}`;

        editingRow.cells[3].innerText =
            `${yearLevel} - ${semester}`;

        editingRow.cells[4].innerHTML =
            `<span class="status ${statusClass}">
                ${status}
            </span>`;
    }

    updateCounts();

    closeModal();
}

function editEnrolment(button) {

    editingRow =
        button.parentElement.parentElement;

    document.getElementById("modalTitle").innerText =
        "Edit Enrolment";

    let student =
        editingRow.cells[1].innerText.split("\n");

    let course =
        editingRow.cells[2].innerText.split("\n");

    let yearSemester =
        editingRow.cells[3].innerText.split(" - ");

    document.getElementById("studentName").value =
        student[0];

    document.getElementById("studentId").value =
        student[1];

    document.getElementById("courseCode").value =
        course[0];

    document.getElementById("courseName").value =
        course[1];

    document.getElementById("yearLevel").value =
        yearSemester[0];

    document.getElementById("semester").value =
        yearSemester[1];

    document.getElementById("status").value =
        editingRow.cells[4].innerText.trim();

    document.getElementById("enrolmentModal").style.display =
        "flex";
}

function deleteEnrolment(button) {

    if (confirm("Delete this enrolment?")) {

        let row =
            button.parentElement.parentElement;

        row.remove();

        updateCounts();
    }
}

function viewEnrolment(button) {

    let row =
        button.parentElement.parentElement;

    alert(row.innerText);
}

function searchEnrolment() {

    let input =
        document.getElementById("searchInput")
            .value
            .toLowerCase();

    let rows =
        document.querySelectorAll("#enrolmentTable tr");

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
        document.querySelectorAll("#enrolmentTable tr");

    let enrolled = 0;
    let dropped = 0;
    let completed = 0;

    rows.forEach(row => {

        let status =
            row.cells[4].innerText.trim();

        if (status === "Enrolled") {
            enrolled++;
        }
        else if (status === "Dropped") {
            dropped++;
        }
        else {
            completed++;
        }
    });

    document.getElementById("totalEnrolments").innerText =
        rows.length;

    document.getElementById("enrolledCount").innerText =
        enrolled;

    document.getElementById("droppedCount").innerText =
        dropped;

    document.getElementById("completedCount").innerText =
        completed;
}