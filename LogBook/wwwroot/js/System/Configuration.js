function openProjectPage(id) {
    document.location.href = "/Configuration/Project?id=" + id;
}

function createNewProjectModel() {
    Swal.fire({
        title: "Create a new project",
        html: `<input class="form-control w-100" type="text" id="createProjectName" placeholder="Project Name">`,
        showCancelButton: true,
        confirmButtonText: "Create"
    })
        .then(result => {
            //AJAX to /Configuration/CreateProject
            $.ajax({
                url: `/Configuration/CreateProject?name=${$("#createProjectName").val()}`,
                contentType: 'application/html; charset=utf-8',
                type: 'POST',
                success: function (data) {
                    console.log(data);

                    location.replace(`/Configuration/Project?id=${data}`);

                    //$("#projectName").val(data.name);
                    //data.logTypes.forEach(l => {
                    //    $("#projectLogTypes").append(`<p>${l.name}</p>`);
                    //});
                    //data.assignees.forEach(l => {
                    //    $("#projectAssignees").append(`<p>${l.userName} - ${l.roleName} ${l.inviteAccepted == null ? " - Invitation Not Accepted" : ""}</p>`);
                    //});
                },
                error: function (data) {
                    Swal.fire({
                        icon: "error"
                    });
                }
            });

        });
}

function openProjectModal(id, name, logs, types, users) {
    Swal.fire({
        title: name,
        html: `Number of logs: ${logs}<br/>Number of log types: ${types}<br/>Number of assigned users: ${users}`,
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Edit",
        denyButtonText: `Delete`
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire("Saved!", "", "success");
        }
        else if (result.isDenied) {
            Swal.fire({
                title: `Delete ${name}`,
                html: `To Delete this project, type "<b>${name}</b>" in the box below<br/> <input id="inputConfirmDeleteName" class="form-control text-center" type='text' />`,
                icon: "warning",
                confirmButtonText: "Delete this project",
                confirmButtonColor: 'red',
                showCancelButton: true
            }).then((result) => {
                if (result.isConfirmed) {
                    if (name == $("#inputConfirmDeleteName").val()) {
                        fetch('/Configuration/RemoveProject?projectId=' + id, {
                            method: "POST",
                        })
                            .then(response => response.json())
                            .then(data => {
                                Swal.fire("Deleted!", "", "success");
                            });
                    }
                    else {
                        Swal.fire("Failed!", "Project Name incorrectly entered", "error");
                    }
                }
            });
        }
    });
}