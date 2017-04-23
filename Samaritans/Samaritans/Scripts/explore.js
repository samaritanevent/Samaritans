$(document).ready(function ()
{
    ShowMore();
});

function ShowMore(dateTime)
{
    $.ajax({
        url: "/Event/ShowMore",
        dataType: "json",
        data: {
            startDate: dateTime,
            offset: $("#ShowMoreOffset").val()
        },
        success: function (data)
        {
            var lastOffset = $("#ShowMoreOffset").val();
            $("#ShowMoreOffset").val(lastOffset + 1);

            $("#EventFlexBox").html(data);
            alert("Much success.");
            //callback(data);
        }
    });
}