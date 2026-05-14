let editingRow = null;

function openAddModal() {

    editingRow = null;

    document.getElementById("modalTitle").innerText = "Add Course";

    clearForm();

    document.getElementById("courseModal").style.display = "flex";
}

function closeModal() {
    document.getElementById("courseModal").style.display = "none";
}

function clearForm() {

    document.getElementById("courseId").value = "";
    document.getElementById("courseName").value = "";
    document.getElementById("department").value = "";
    document.getElementById("yearSemester").value = "";
    document.getElementById("units").value = "";
    document.getElementById("status").value = "Active";
}

function saveCourse() {

    let courseId = document.getElementById("courseId").value;
    let courseName = document.getElementById("courseName").value;
    let department = document.getElementById("department").value;
    let yearSemester = document.getElementById("yearSemester").value;
    let units = document.getElementById("units").value;
    let status = document.getElementById("status").value;

    if (
        courseId === "" ||
        courseName === "" ||
        department === "" ||
        yearSemester === "" ||
        units === ""
    ) {
        alert("Please fill in all fields.");
        return;
    }

    let statusClass =
        status === "Active"
            ? "active-status"
            : "inactive-status";

    if (editingRow == null) {

        let table = document.getElementById("courseTable");

        let row = table.insertRow();

        row.innerHTML = `
            <td>${courseId}</td>
            <td>${courseName}</td>
            <td>${department}</td>
            <td>${yearSemester}</td>
            <td>${units}</td>

            <td>
                <span class="status ${statusClass}">
                    ${status}
                </span>
            </td>

            <td class="actions">

                <i class="fa-solid fa-eye view"
                   onclick="viewCourse(this)"></i>

                <i class="fa-solid fa-pen-to-square edit"
                   onclick="editCourse(this)"></i>

                <i class="fa-solid fa-trash delete"
                   onclick="deleteCourse(this)"></i>

            </td>
        `;

    } else {

        editingRow.cells[0].innerText = courseId;
        editingRow.cells[1].innerText = courseName;
        editingRow.cells[2].innerText = department;
        editingRow.cells[3].innerText = yearSemester;
        editingRow.cells[4].innerText = units;

        editingRow.cells[5].innerHTML = `
            <span class="status ${statusClass}">
                ${status}
            </span>
        `;
    }

    updateCounts();

    closeModal();
}

function editCourse(button) {

    editingRow = button.parentElement.parentElement;

    document.getElementById("modalTitle").innerText = "Edit Course";

    document.getElementById("courseId").value =
        editingRow.cells[0].innerText;

    document.getElementById("courseName").value =
        editingRow.cells[1].innerText;

    document.getElementById("department").value =
        editingRow.cells[2].innerText;

    document.getElementById("yearSemester").value =
        editingRow.cells[3].innerText;

    document.getElementById("units").value =
        editingRow.cells[4].innerText;

    document.getElementById("status").value =
        editingRow.cells[5].innerText.trim();

    document.getElementById("courseModal").style.display = "flex";
}

function deleteCourse(button) {

    if (confirm("Are you sure you want to delete this course?")) {

        let row = button.parentElement.parentElement;

        row.remove();

        updateCounts();
    }
}

function viewCourse(button) {

    let row = button.parentElement.parentElement;

    alert(
        "Course ID: " + row.cells[0].innerText + "\n" +
        "Course Name: " + row.cells[1].innerText + "\n" +
        "Department: " + row.cells[2].innerText + "\n" +
        "Year/Semester: " + row.cells[3].innerText + "\n" +
        "Units: " + row.cells[4].innerText + "\n" +
        "Status: " + row.cells[5].innerText
    );
}

function searchCourse() {

    let input =
        document.getElementById("searchInput").value.toLowerCase();

    let rows =
        document.querySelectorAll("#courseTable tr");

    rows.forEach(row => {

        let text = row.innerText.toLowerCase();

        row.style.display =
            text.includes(input)
                ? ""
                : "none";
    });
}

function updateCounts() {

    let rows =
        document.querySelectorAll("#courseTable tr");

    let total = rows.length;

    let active = 0;
    let inactive = 0;

    rows.forEach(row => {

        let status =
            row.cells[5].innerText.trim();

        if (status === "Active") {
            active++;
        } else {
            inactive++;
        }
    });

    document.getElementById("totalCourses").innerText = total;
    document.getElementById("activeCount").innerText = active;
    document.getElementById("inactiveCount").innerText = inactive;
}