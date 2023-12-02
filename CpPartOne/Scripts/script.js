window.onload = function () {

    // getting form from html
    var addTeacherForm = document.forms["addTeacherForm"];

    // form fields
    var userInputFirstName = addTeacherForm["teacherFirstName"];
    var userInputLastName = addTeacherForm["teacherLastName"];
    var userInputEmployeeNumber = addTeacherForm["employeeNumber"];
    var userInputHireDate = addTeacherForm["teacherHireDate"];
    var userInputSalary = addTeacherForm["teacherSalary"];

    //submit btn
    var submitBtn = document.getElementById("btnDelete")

    // event listener on btn
    submitBtn.addEventListener('click', (event) => {

        // to stop the submit
        event.preventDefault()

        // validate fullname
        if (userInputFirstName.value === "") {
            alert("First name field is empty.");
            return false;
        }

        // validate lastname
        if (userInputLastName.value === "") {
            alert("Last name field is empty.");
            return false;
        }

        // validate employee number
        if (userInputEmployeeNumber.value === "") {
            alert("Employee number field is empty.");
            return false;
        }

        // validate hire date
        if (userInputHireDate.value === "") {
            alert("Hire date field is empty.");
            return false;
        }

        // validate salary
        var salaryValue = parseFloat(userInputSalary.value);

        if (isNaN(salaryValue)) {
            alert("Salary field is empty or contains an invalid value.");
            return false;
        }

        // salary can't be in minus
        if (userInputSalary.value < 0) {
            alert("Salary field can not have value in negative. Please enter again");
            return false;
        }

        // if all validation are passed
        addTeacherForm.submit();


    });



}