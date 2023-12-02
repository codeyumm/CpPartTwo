window.onload = function () {

    // getting delete button from dom
    var deleteBtn = document.getElementsByClassName('myBtn')[0];

    // event listener of delete button
    deleteBtn.addEventListener("click", (event) => {
        // prvent default so when user click on link
        // it doesn't redirect to href
        event.preventDefault();

        // storing user choice to delete the data or not
        var userChoice = confirm("Data will be deleted permenantly, are you sure about this action?")

        // if user choice is no
        if (userChoice === false) {

            // do nothing
            return false;
        } else {

            // if user choice is yes
            // go the href
            window.location.href = deleteBtn.getAttribute('href');
        }
    });

}