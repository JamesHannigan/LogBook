window.onload = function () {
    fetch(`/System/RecordPageLoad?path=${window.location.pathname + window.location.search}`, {
        method: 'post',
    });

    fetch('/Configuration/GetUsersProjects')
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            let dashboardList = `<li><a href="/" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Overview</a></li>`;
            let activityList = `<li><a href="/Activity" class="link-body-emphasis d-inline-flex text-decoration-none rounded">Overview</a></li>`;
            data.forEach(d => {
                dashboardList += `<li><a href="/?Project=${d.publicId}" class="link-body-emphasis d-inline-flex text-decoration-none rounded">${d.name}</a></li>`;
                activityList += `<li><a href="/Activity?Project=${d.publicId}" class="link-body-emphasis d-inline-flex text-decoration-none rounded">${d.name}</a></li>`;
            });
            $("#navigationDashboardList").html(dashboardList);
            $("#navigationActivityList").html(activityList);
        });

}