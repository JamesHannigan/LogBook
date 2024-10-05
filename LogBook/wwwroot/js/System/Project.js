const urlParams = new URLSearchParams(window.location.search.toLowerCase());
let projectGUID = urlParams.get('id');

$(document).ready(function () {
    $("#projectGUID").val(projectGUID);
    $("#logTypeProjectGUID").val(projectGUID);
    $.ajax({
        url: `/Configuration/GetProjectWithData?projectGUID=${projectGUID}`,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        success: function (data) {
            console.log(data);
            $("#projectName").text(data.name);
            data.logTypes.forEach(l => {
                $("#projectLogTypes").append(`<p>${l.name}</p>`);
            });
            data.assignees.forEach(l => {
                $("#projectAssignees").append(`<p>${l.userName} - ${l.roleName} ${l.inviteAccepted == null ? " - Invitation Not Accepted" : ""}</p>`);
            });
        },
        error: function (data) {
            Swal.fire({
                icon: "error"
            });
        }
    });
});