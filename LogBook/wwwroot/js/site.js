window.onload = function () {
    fetch(`/System/RecordPageLoad?path=${window.location.pathname + window.location.search}`, {
        method: 'post',
    })
}