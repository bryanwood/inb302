function AjaxValidateAndGo(caller, postURL, validateDiv) {

var serialized = $(caller).serialize();

$.ajax({
    type: "POST",
    url: postURL,
    data: serialized,
    statusCode: {

    201: function(data) {
    window.location.assign(data.GoTo);
    },
    400: function(data) {
    var reply = $.parseJSON(data.responseText);
    $(validateDiv).html(reply.FailureReason);
    $(validateDiv).slideDown(500);
    $(validateDiv).animate({ opacity: 1.0 }, 500);

    }

    }
    })
return false;

}