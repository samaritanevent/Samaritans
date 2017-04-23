$(document).ready(function ()
{
    ShowMore();
});

function ShowMore()
{
    $.ajax({
        url: "/Event/ShowMore",
        dataType: "json",
        data: {
            currentOffset: $("#CurrentOffset").val()
        },
        complete: function (data)
        {
            $("#EventFlexBox").html(data.responseText);
        }
    });
}