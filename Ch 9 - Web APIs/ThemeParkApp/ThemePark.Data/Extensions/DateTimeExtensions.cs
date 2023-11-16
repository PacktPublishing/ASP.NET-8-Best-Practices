namespace ThemePark.Data.Extensions;

public static class DateTimeExtensions
{
    public static string ToFormattedDateTime(this DateTime dateAndTime, bool includeTime = true)
    {
        var dateSuffix = "<sup>th</sup>";
        switch (dateAndTime.Day)
        {
            case 1:
            case 21:
            case 31:
                dateSuffix = "<sup>st</sup>";
                break;

            case 2:
            case 22:
                dateSuffix = "<sup>nd</sup>";
                break;

            case 3:
            case 23:
                dateSuffix = "<sup>rd</sup>";
                break;
        }

        var dateFmt =
            $"{dateAndTime:MMMM} {dateAndTime:%d}{dateSuffix}, {dateAndTime:yyyy} at {dateAndTime:%h}:{dateAndTime:mm}{dateAndTime.ToString("tt").ToLower()}";

        if (!includeTime)
        {
            dateFmt = $"{dateAndTime:MMMM} {dateAndTime:%d}{dateSuffix}, {dateAndTime:yyyy}";
        }

        return dateFmt;
    }
}