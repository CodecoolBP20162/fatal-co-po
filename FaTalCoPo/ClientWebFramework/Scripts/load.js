function LoadComputers() {
    $(document).ready(function () {
        $.ajax({
            url: '/Computer/LoadComputers',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html'
        })
            .success(function (result) {
                $('#computers').empty();
                $('#computers').html(result);
            })
            .error(function (jqXHR, exception) {
                //getErrorMessage(jqXHR, exception);
                $('#computers').empty();
                $('#computers').html("No computers found.");
            });
    });
}

function getErrorMessage(jqXHR, exception) {
    var content = "\nSomething went wrong. Please try again.";
    var msg = '';
    if (jqXHR.status === 0) {
        msg = 'Cannot connect.\n Verify Network.' + content;
    } else if (jqXHR.status === 404) {
        msg = 'Requested page not found. [404]' + content;
    } else if (jqXHR.status === 500) {
        msg = 'Internal Server Error [500].' + content;
    } else if (exception === 'parsererror') {
        msg = 'Requested JSON parse failed.' + content;
    } else if (exception === 'timeout') {
        msg = 'Timeout error.' + content;
    } else if (exception === 'abort') {
        msg = 'Ajax request aborted.' + content;
    } else {
        msg = 'Uncaught Error.\n' + jqXHR.responseText + content;
    }
    alert(msg);
}
