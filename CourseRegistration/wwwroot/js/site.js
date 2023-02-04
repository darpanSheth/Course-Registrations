


function showStudents(courseId) {
    if (document.getElementById("student-in-" + courseId).style.display == "none") {
        document.getElementById("student-in-" + courseId).style.display = "block";
    }
    else if (document.getElementById("student-in-" + courseId).style.display == "block") {
        document.getElementById("student-in-" + courseId).style.display = "none";
    }
}

function hideStudents(courseId) {
    document.getElementById("student-in-" + courseId).style.display = "none";
}

