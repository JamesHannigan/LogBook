let urlParams = new URLSearchParams(window.location.search);
let typeQuery = urlParams.get('Type');

let filtersData = [
    { id: 0, name: "Date", data: [{ id: 0, name: "Today" }, { id: 1, name: "This Week" }, { id: 2, name: "This Month" }, { id: 3, name: "Custom Range" }] },
    { id: 1, name: "Project", data: [{ id: 1, name: "LogBook" }, { id: 2, name: "Test Project" }] },
    { id: 2, name: "Type", data: [{ id: 1, name: "Page Visit" }, { id: 2, name: "Error Reported" }, { id: 3, name: "Information Logged" }] },
    { id: 3, name: "User", data: [{ id: 0, name: "System" }, { id: 1, name: "Developer" }, { id: 2, name: "James Hannigan" }] }
];

//urlParams.set('Search', $scope.SearchTerm);
//urlParams.delete('Subhire');
//window.location.pathname + "?" + urlParams.toString()
//history.pushState(null, null, window.location.pathname + "?" + urlParams.toString());

$(document).ready(function () {
    buildFiltersRow();
    buildLogs();
});

function buildFiltersRow() {
    let filters = "";
    filtersData.forEach(f => {
        let selected = "";

        //Depending on the parameter, either we give a tick or a minus sign to suggest a filter has filters added.
        let filterQueryParam = urlParams.get(f.name);
        if (filterQueryParam != null && filterQueryParam != "") {
            let filterQuery = filterQueryParam.split(",");
            let filterData = f.data.map(m => m.id.toString());
            let allFiltersSelected = filterData.every(v => filterQuery.includes(v));

            selected = allFiltersSelected ? '<i class="fa-solid fa-check text-secondary" style="font-size: 12px"></i>' : '<i class="fa-solid fa-minus text-secondary" style="font-size: 12px"></i>'
        }

        filters += `<span id="filterOption${f.id}" onclick="toggleFilters(this)" class="cursor-pointer user-select-none small me-1 px-3 py-1 rounded-5 bg-white bg-hover-secondary bg-opacity-10 border border-1">${f.name} ${selected}</span>`;
    });
    $("#filtersRow").html(filters);
}

function buildLogs() {
    console.log(urlParams.toString());
    htmx.ajax('GET', `/Activity/GetActivitiesAsTableRows?${urlParams.toString()}`, '#logsTable');
}

function toggleFilters(selectedFilter) {
    let filtersRow = $("#subFiltersRow");

    if (!filtersRow.hasClass("d-none") && $(selectedFilter).hasClass("selectedFilter")) {
        filtersRow.addClass("d-none");
        $(".selectedFilter").removeClass("selectedFilter");
    }
    else {
        $(".selectedFilter").removeClass("selectedFilter");
        $(selectedFilter).addClass("selectedFilter");
        let filterIndex = selectedFilter.id.replace("filterOption", "");
        let subFilters = "";
        let queryIndexesString = urlParams.get(filtersData[filterIndex].name);
        let queryIndexes = queryIndexesString != null && queryIndexesString != "" ? queryIndexesString.split(",") : [];

        filtersData[filterIndex].data.forEach(f => {

            //Get filter name from index, then get the parameter values

            //If the number matches, then use else

            if (queryIndexes.includes(f.id.toString())) {
                subFilters += `<span class="cursor-pointer user-select-none small me-1 px-3 py-1 rounded-5 bg-secondary bg-opacity-10 border border-1">${f.name} <i class="fa-solid fa-check text-secondary" style="font-size: 12px"></i></span>`;
            }
            else {
                subFilters += `<span class="cursor-pointer user-select-none small me-1 px-3 py-1 rounded-5 bg-white bg-hover-secondary bg-opacity-10 border border-1">${f.name}</span>`;
            }
        });
        $("#subFilters").html(subFilters);
        filtersRow.removeClass("d-none");
    }

    //function toggleSubFilter(this) {
        //let typeQuery = urlParams.get('Type');

        //Get the name of the url param

        //Get the ID maybe from the button

        //Check if ID is already added

        //Get list as array

        //If ID exists, remove

        //If not, add

        //SET parameters

        //reload subfilters

        //Reload logs data
    //}
}