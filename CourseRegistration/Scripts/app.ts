function handleCreateStudent(e: SubmitEvent) {
    const studentFirstName = document.getElementById("FirstName");
    const studentLastName = document.getElementById("LastName");
    const studentPhoneNumber = document.getElementById("PhoneNumber");

    if (!studentFirstName || !studentLastName || !studentPhoneNumber) {
        e.preventDefault();
        return false;
    }

    

    if ((studentFirstName instanceof HTMLInputElement) && (studentLastName instanceof HTMLInputElement) && (studentPhoneNumber instanceof HTMLInputElement)) {
        if ((!studentFirstName.value || !studentFirstName.value.trim()) && (!studentLastName.value || !studentLastName.value.trim()) && (!studentPhoneNumber.value || !studentPhoneNumber.value.trim())) {
            e.preventDefault();
            alert("First Name, Last Name and Phone Number fields cannot be empty")
        }

        else if ((!studentFirstName.value || !studentFirstName.value.trim()) && (!studentLastName.value || !studentLastName.value.trim())) {
            e.preventDefault();
            alert("First Name and Last Name fields cannot be empty")
        }

        else if ((!studentFirstName.value || !studentFirstName.value.trim()) && (!studentPhoneNumber.value || !studentPhoneNumber.value.trim())) {
            e.preventDefault();
            alert("First Name and Phone Number fields cannot be empty")
        }

        else if ((!studentLastName.value || !studentLastName.value.trim()) && (!studentPhoneNumber.value || !studentPhoneNumber.value.trim())) {
            e.preventDefault();
            alert("Last Name and Phone Number fields cannot be empty")
        }

        else if (!studentFirstName.value || !studentFirstName.value.trim()) {
            e.preventDefault();
            alert("First Name field cannot be empty")
        }

        else if (!studentLastName.value || !studentLastName.value.trim()) {
            e.preventDefault();
            alert("Last Name field cannot be empty")
        }

        else if (!studentPhoneNumber.value || !studentPhoneNumber.value.trim()) {
            e.preventDefault();
            alert("Phone Number field cannot be empty")
        }
    }

    return true;
}

function handleCreateInstructor(e: SubmitEvent) {
    const instructorFirstName = document.getElementById("FirstName");
    const instructorLastName = document.getElementById("LastName");
    const instructorCourseId = document.getElementById("CourseId");

    if (!instructorFirstName || !instructorLastName || !instructorCourseId) {
        e.preventDefault();
        return false;
    }



    if ((instructorFirstName instanceof HTMLInputElement) && (instructorLastName instanceof HTMLInputElement) && (instructorCourseId instanceof HTMLInputElement)) {
        if ((!instructorFirstName.value || !instructorFirstName.value.trim()) && (!instructorLastName.value || !instructorLastName.value.trim()) && (!instructorCourseId.value || !instructorCourseId.value.trim())) {
            e.preventDefault();
            alert("First Name, Last Name and Course Id fields cannot be empty")
        }

        else if ((!instructorFirstName.value || !instructorFirstName.value.trim()) && (!instructorLastName.value || !instructorLastName.value.trim())) {
            e.preventDefault();
            alert("First Name and Last Name fields cannot be empty")
        }

        else if ((!instructorFirstName.value || !instructorFirstName.value.trim()) && (!instructorCourseId.value || !instructorCourseId.value.trim())) {
            e.preventDefault();
            alert("First Name and Course Id fields cannot be empty")
        }

        else if ((!instructorLastName.value || !instructorLastName.value.trim()) && (!instructorCourseId.value || !instructorCourseId.value.trim())) {
            e.preventDefault();
            alert("Last Name and Course Id fields cannot be empty")
        }

        else if (!instructorFirstName.value || !instructorFirstName.value.trim()) {
            e.preventDefault();
            alert("First Name field cannot be empty")
        }

        else if (!instructorLastName.value || !instructorLastName.value.trim()) {
            e.preventDefault();
            alert("Last Name field cannot be empty")
        }

        else if (!instructorCourseId.value || !instructorCourseId.value.trim()) {
            e.preventDefault();
            alert("Course Id field cannot be empty")
        }
    }

    return true;
}

function handleCreateCourse(e: SubmitEvent) {
    const courseName = document.getElementById("CourseName");
    const courseNumber = document.getElementById("CourseNumber");
    const courseDescription = document.getElementById("Description");

    if (!courseName || !courseNumber || !courseDescription) {
        e.preventDefault();
        return false;
    }



    if ((courseName instanceof HTMLInputElement) && (courseNumber instanceof HTMLInputElement) && (courseDescription instanceof HTMLInputElement)) {
        if ((!courseName.value || !courseName.value.trim()) && (!courseNumber.value || !courseNumber.value.trim()) && (!courseDescription.value || !courseDescription.value.trim())) {
            e.preventDefault();
            alert("Name, Number and Description fields cannot be empty")
        }

        else if ((!courseName.value || !courseName.value.trim()) && (!courseNumber.value || !courseNumber.value.trim())) {
            e.preventDefault();
            alert("Name and Number fields cannot be empty")
        }

        else if ((!courseName.value || !courseName.value.trim()) && (!courseDescription.value || !courseDescription.value.trim())) {
            e.preventDefault();
            alert("Name and Description fields cannot be empty")
        }

        else if ((!courseNumber.value || !courseNumber.value.trim()) && (!courseDescription.value || !courseDescription.value.trim())) {
            e.preventDefault();
            alert("Number and Description fields cannot be empty")
        }

        else if (!courseName.value || !courseName.value.trim()) {
            e.preventDefault();
            alert("Name field cannot be empty")
        }

        else if (!courseNumber.value || !courseNumber.value.trim()) {
            e.preventDefault();
            alert("Number field cannot be empty")
        }

        else if (!courseDescription.value || !courseDescription.value.trim()) {
            e.preventDefault();
            alert("Description field cannot be empty")
        }
    }

    return true;
}