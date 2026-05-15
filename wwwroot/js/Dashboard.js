const dashboardData = {
    students: 120,
    teachers: 15,
    courses: 8,
    attendance: 92
};

// UPDATE DASHBOARD CARDS
document.getElementById("students").textContent = dashboardData.students;
document.getElementById("teachers").textContent = dashboardData.teachers;
document.getElementById("courses").textContent = dashboardData.courses;
document.getElementById("attendance").textContent = dashboardData.attendance + "%";

// SAMPLE ACTIVITIES DATA
const activities = [
    {
        name: "Juan Dela Cruz",
        status: "Present",
        course: "BSIT 2A",
        icon: "fa-user-check",
        type: "present"
    },
];
// LOAD ACTIVITIES INTO HTML
const activityList = document.getElementById("activity-list");

activityList.innerHTML = ""; 

activities.forEach(activity => {

    const div = document.createElement("div");
    div.classList.add("activity");

    div.innerHTML = `
        <i class="fa-solid ${activity.icon}"></i>

        <div>
            <strong>${activity.name}</strong>
            marked
            <span class="${activity.type}">${activity.status}</span>

            <p>${activity.course}</p>
        </div>
    `;

    activityList.appendChild(div);
});