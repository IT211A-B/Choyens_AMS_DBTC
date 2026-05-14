// DASHBOARD COUNTS

let totalStudents = 156;
let totalTeachers = 18;
let totalCourses = 12;
let attendanceRate = 94;

// LOAD DASHBOARD

window.onload = function () {

    animateValue("students", totalStudents);
    animateValue("teachers", totalTeachers);
    animateValue("courses", totalCourses);

    animatePercentage(
        "attendance",
        attendanceRate
    );

    loadActivities();
};

// ANIMATION COUNTER

function animateValue(id, endValue) {

    let element =
        document.getElementById(id);

    let startValue = 0;

    let duration = 1000;

    let increment =
        endValue / (duration / 20);

    let counter = setInterval(() => {

        startValue += increment;

        if (startValue >= endValue) {

            startValue = endValue;

            clearInterval(counter);
        }

        element.innerText =
            Math.floor(startValue);

    }, 20);
}

// PERCENTAGE ANIMATION

function animatePercentage(id, endValue) {

    let element =
        document.getElementById(id);

    let startValue = 0;

    let duration = 1000;

    let increment =
        endValue / (duration / 20);

    let counter = setInterval(() => {

        startValue += increment;

        if (startValue >= endValue) {

            startValue = endValue;

            clearInterval(counter);
        }

        element.innerText =
            Math.floor(startValue) + "%";

    }, 20);
}

// RECENT ACTIVITIES

function loadActivities() {

    let activities = [

        {
            name: "Jan Arles",
            status: "Present",
            course: "BSME - 1",
            icon: "fa-user-check"
        },

        {
            name: "Raphael Pal",
            status: "Present",
            course: "BSIT - 2",
            icon: "fa-user-check"
        },

        {
            name: "Irish Dela Cruz",
            status: "Present",
            course: "BSIT - 1",
            icon: "fa-user-check"
        },

        {
            name: "Vanneza Domen",
            status: "Absent",
            course: "BSIT - 1",
            icon: "fa-user-xmark"
        },

        {
            name: "Nine Boragay",
            status: "Late",
            course: "BSIT - 2",
            icon: "fa-clock"
        }

    ];

    let activityList =
        document.getElementById("activity-list");

    activityList.innerHTML = "";

    activities.forEach(activity => {

        let statusClass = "";

        if (activity.status === "Present") {

            statusClass = "present";
        }
        else if (activity.status === "Absent") {

            statusClass = "absent";
        }
        else {

            statusClass = "late";
        }

        activityList.innerHTML += `

            <div class="activity">

                <i class="fa-solid ${activity.icon}"></i>

                <div>

                    <strong>${activity.name}</strong>
                    marked

                    <span class="${statusClass}">
                        ${activity.status}
                    </span>

                    <p>${activity.course}</p>

                </div>

            </div>
        `;
    });
}