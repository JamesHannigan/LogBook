let urlParams = new URLSearchParams(window.location.search);
let start = urlParams.get('Start') != null ? moment(urlParams.get('Start'), "YYYY-MM-DD") : moment();
let end = urlParams.get('End') != null ? moment(urlParams.get('End'), "YYYY-MM-DD") : (urlParams.get('Start') != null ? moment(urlParams.get('Start'), "YYYY-MM-DD") : moment());

const selectedClasses = "cursor-pointer user-select-none small text-nowrap me-1 px-3 py-1 rounded-5 bg-secondary bg-opacity-10 border border-1 selectedSubFilter";
const unselectedClasses = "cursor-pointer user-select-none small text-nowrap me-1 px-3 py-1 rounded-5 bg-white bg-hover-secondary bg-opacity-10 border border-1";

let filtersData = [];

jQuery(function () {
    fetch('/Activity/GetFiltersData') // api for the get request
        .then(response => response.json())
        .then(data => {
            console.log(data);
            filtersData = [
                { id: 0, name: "Date", data: [{ id: 0, name: "Today" }, { id: 1, name: "This Week" }, { id: 2, name: "This Month" }, { id: 3, name: "Custom Range" }] },
                { id: 1, name: "Project", data: data.projects },
                { id: 2, name: "Type", data: data.types },
                { id: 3, name: "User", data: [{ id: 0, name: "System" }, { id: 1, name: "Developer" }, { id: 2, name: "James Hannigan" }] }
            ];

            buildFiltersRow();
            buildLogs();
        });
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

        filters += `<span id="filterOption${f.id}" ${(f.id != 0 ? `onclick="toggleFilters(this)"` : ``)} class="cursor-pointer user-select-none small me-1 px-3 py-1 rounded-5 bg-light bg-hover-secondary bg-opacity-10 border border-1">${f.name} ${selected}</span>`;
    });
    $("#filtersRow").html(filters);
    buildDateRangePicker();
}

function buildLogs() {
    console.log(urlParams.toString());
    htmx.ajax('GET', `/Activity/GetActivitiesAsTableRows?${urlParams.toString()}`, '#logsTable');
}

function buildDateRangePicker() {
    $('#filterOption0').daterangepicker({
        startDate: start,
        endDate: end,
        ranges: {
            'Today': [moment(), moment()],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            /*'Last 30 Days': [moment().subtract(29, 'days'), moment()],*/
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            /*'This Year': [moment().startOf('year'), moment().endOf('year')],*/
        }
    }, function (start, end, label) {

        urlParams.set("Start", start.format("YYYY-MM-DD"));
        urlParams.set("End", end.format("YYYY-MM-DD"));
        history.pushState(null, null, window.location.pathname + "?" + urlParams.toString());
        buildLogs();
    });
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
                subFilters += `<span id="subFilter${filtersData[filterIndex].id}~${filtersData[filterIndex].name}~${f.id}~${f.name}" onclick="toggleSubFilter(this)" class="${selectedClasses}">${f.name} <i class="fa-solid fa-check text-secondary" style="font-size: 12px"></i></span>`;
            }
            else {
                subFilters += `<span id="subFilter${filtersData[filterIndex].id}~${filtersData[filterIndex].name}~${f.id}~${f.name}" onclick="toggleSubFilter(this)" class="${unselectedClasses}">${f.name}</span>`;
            }
        });
        $("#subFilters").html(subFilters);
        filtersRow.removeClass("d-none");
    }
}

function toggleSubFilter(subFilter) {
    debugger;
    let filterAndId = subFilter.id.replace("subFilter", "");
    let filterId = filterAndId.split("~")[0];
    let filterName = filterAndId.split("~")[1];
    let subFilterId = filterAndId.split("~")[2];
    let subFilterName = filterAndId.split("~")[3];

    //Check if ID is already added
    let queryFilter = urlParams.get(filterName);

    if (queryFilter == null || queryFilter == "") {
        urlParams.set(filterName, subFilterId);
    }
    else {
        let queryArray = queryFilter.split(",");
        if (queryArray.includes(subFilterId)) {
            const index = queryArray.indexOf(subFilterId);
            if (index > -1) { // only splice array when item is found
                queryArray.splice(index, 1); // 2nd parameter means remove one item only
            }
        }
        else {
            queryArray.push(subFilterId);
        }

        urlParams.set(filterName, queryArray.join(","));

        //Get list, convert to array
        //add or remove id
    }

    //If selectedSubFilter class exists, remove relevant class, etc.
    //Else other state


    //Does element have selectedSubFilter class
    if ($(subFilter).hasClass("selectedSubFilter")) {
        $(subFilter).attr('class', unselectedClasses);
        $(subFilter).html(subFilterName);
    }
    else {
        $(subFilter).attr('class', selectedClasses);
        $(subFilter).html(subFilterName + ` <i class="fa-solid fa-check text-secondary" style="font-size: 12px"></i>`);
    }

    //urlParams.set('Search', $scope.SearchTerm);
    //urlParams.delete('Subhire');
    //window.location.pathname + "?" + urlParams.toString()
    history.pushState(null, null, window.location.pathname + "?" + urlParams.toString());
    buildFiltersRow();
    $("#filterOption" + filterId).addClass('selectedFilter');
    //$("#filterOption" + filterId).attr('class', selectedClasses);

    //Finally, rebuild the data on the page.
    buildLogs();
}