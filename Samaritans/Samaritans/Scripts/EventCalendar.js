$(document).ready(function ()
{
    $("#calendar").fullCalendar({
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