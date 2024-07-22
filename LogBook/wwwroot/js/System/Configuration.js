function openProjectPage(id) {
    document.location.href = "/Configuration/Project?id=" + id;
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