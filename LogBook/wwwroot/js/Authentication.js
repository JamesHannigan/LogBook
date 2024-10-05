function openOption(action) {
    $("#loginForm").addClass("d-none");
    $("#registerForm").addClass("d-none");
    $("#registerErrorMessages").addClass("d-none");
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

function submitRegisterForm() {
    console.log($('#registerFormData').serializeArray());

    if ($("#registerPassword").val() != $("#registerConfirmPassword").val()) {
        $("#registerErrorMessages").html("Passwords do not match");
        $("#registerErrorMessages").removeClass("d-none");
        return;
    }

    $.ajax({
        url: `/Authentication/RegisterUser`,
        type: "POST",
        data: $('#registerFormData').serializeArray(),
        dataType: "JSON",
        contentType: "application/x-www-form-urlencoded",
        success: function (response) {
            console.log(response);
            if (response.length == 0) {
                window.location.replace("/");
            }
            else {
                //Error message
                console.log(response);
                $("#registerErrorMessages").html(response);
                $("#registerErrorMessages").removeClass("d-none");
            }
        },
        error: function (xhr, status) {
            Swal.fire({
                title: "An error has occurred",
                text: error,
                icon: "error"
            });
        },
    });
}