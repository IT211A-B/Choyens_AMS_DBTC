// DEFAULT DATA

if (!localStorage.getItem("students")) {

    let students = [

        {
            id: 1,
            name: "Jan Artes",
            course: "BSME - 1"
        },

        {
            id: 2,
            name: "Palipapo Karol",
            course: "BSIT - 2"
        }

    ];

    localStorage.setItem(
        "students",
        JSON.stringify(students)
    );
}

if (!localStorage.getItem("teachers")) {

    let teachers = [

        {
            id: 1,
            name: "Mr. Santos"
        },

        {
            id: 2,
            name: "Ms. Cruz"
        }

    ];

    localStorage.setItem(
        "teachers",
        JSON.stringify(teachers)
    );
}

if (!localStorage.getItem("courses")) {

    let courses = [

        {
            id: 1,
            course: "BSIT"
        },

        {
            id: 2,
            course: "BSME"
        },

        {
            id: 3,
            course: "BSBA"
        }

    ];

    localStorage.setItem(
        "courses",
        JSON.stringify(courses)
    );
}

if (!localStorage.getItem("activities")) {

    let activities = [

        {
            name: "Jan Artes",
            status: "Present",
            course: "BSME - 1",
            icon: "fa-user-check"
        },

        {
            name: "Palipapo Karol",
            status: "Late",
            course: "BSIT - 2",
            icon: "fa-user-clock"
        }

    ];

    localStorage.setItem(
        "activities",
        JSON.stringify(activities)
    );
}

// ===============================
// LOAD DASHBOARD
// ===============================

window.onload = function () {

    loadDashboardCounts();

    loadActivities();
};

// ===============================
// LOAD COUNTS
// ===============================

function loadDashboardCounts() {

    let students =
        JSON.parse(localStorage.getItem("students")) || [];

    let teachers =
        JSON.parse(localStorage.getItem("teachers")) || [];

    let courses =
        JSON.parse(localStorage.getItem("courses")) || [];

    let activities =
        JSON.parse(localStorage.getItem("activities")) || [];

    // TOTAL COUNTS

    let totalStudents = students.length;

    let totalTeachers = teachers.length;

    let totalCourses = courses.length;

    // ATTENDANCE COMPUTATION

    let presentCount = activities.filter(
        activity => activity.status === "Present"
    ).length;

    let attendanceRate = 0;

    if (activities.length > 0) {

        attendanceRate =
            Math.round(
                (presentCount / activities.length) * 100
            );
    }

    // ANIMATE VALUES

    animateValue(
        "students",
        totalStudents
    );

    animateValue(
        "teachers",
        totalTeachers
    );

    animateValue(
        "courses",
        totalCourses
    );

    animatePercentage(
        "attendance",
        attendanceRate
    );
}

// ===============================
// ANIMATION COUNTER
// ===============================

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

// ===============================
// PERCENTAGE ANIMATION
// ===============================

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

// ===============================
// LOAD ACTIVITIES
// ===============================

function loadActivities() {

    let activities =
        JSON.parse(localStorage.getItem("activities")) || [];

    let activityList =
        document.getElementById("activity-list");

    activityList.innerHTML = "";

    if (activities.length === 0) {

        activityList.innerHTML = `

            <div class="activity">

                <div>
                    <strong>No Activities Yet</strong>
                </div>

            </div>
        `;

        return;
    }

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

// ===============================
// ADD STUDENT
// ===============================

function addStudent(name, course) {

    let students =
        JSON.parse(localStorage.getItem("students")) || [];

    students.push({

        id: Date.now(),

        name: name,

        course: course
    });

    localStorage.setItem(
        "students",
        JSON.stringify(students)
    );

    loadDashboardCounts();
}

// ===============================
// ADD TEACHER
// ===============================

function addTeacher(name) {

    let teachers =
        JSON.parse(localStorage.getItem("teachers")) || [];

    teachers.push({

        id: Date.now(),

        name: name
    });

    localStorage.setItem(
        "teachers",
        JSON.stringify(teachers)
    );

    loadDashboardCounts();
}

// ===============================
// ADD COURSE
// ===============================

function addCourse(courseName) {

    let courses =
        JSON.parse(localStorage.getItem("courses")) || [];

    courses.push({

        id: Date.now(),

        course: courseName
    });

    localStorage.setItem(
        "courses",
        JSON.stringify(courses)
    );

    loadDashboardCounts();
}

// ===============================
// ADD ATTENDANCE
// ===============================

function addAttendance(name, status, course) {

    let activities =
        JSON.parse(localStorage.getItem("activities")) || [];

    let icon = "fa-user-check";

    if (status === "Absent") {

        icon = "fa-user-xmark";
    }

    if (status === "Late") {

        icon = "fa-user-clock";
    }

    activities.unshift({

        name: name,

        status: status,

        course: course,

        icon: icon
    });

    localStorage.setItem(
        "activities",
        JSON.stringify(activities)
    );

    loadDashboardCounts();

    loadActivities();
}