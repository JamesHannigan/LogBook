function openOption(action) {
    $("#loginForm").addClass("d-none");
    $("#registerForm").addClass("d-none");
    $("#forgottenPasswordForm").addClass("d-none");

    let id = "";
        switch (action) {
            case "Login":
                id = "loginForm";
                break;
            case "Register":
                id = "registerForm";
                break;
            case "Forgotten":
                id = "forgottenPasswordForm";
                break;
            default:
            // code block
    }
    $("#" + id).removeClass("d-none");
}   