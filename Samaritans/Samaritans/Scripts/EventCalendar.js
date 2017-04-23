$(document).ready(function ()
{
    $("#calendar").fullCalendar({
        aspectRatio: 1.5,
        contentHeight: 500,
        height: 500,
        events: function (start, end, timezone, callback)
        {
            $.ajax({
                url: "/Event/GetEvents",
                dataType: "json",
                data: {
                    startDate: start.toISOString(),
                    endDate: end.toISOString()
                },
                success: function (data)
                {
                    callback(data);
                }
            });
        }
    });
});