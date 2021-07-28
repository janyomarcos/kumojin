using System;
using Kumojin.Timezone.Data;

namespace Kumojin.Timezone.Services
{
    public static class TimeZoneService
    {
        public static DateTimeDTO GetDateTimeDTO(string timezoneId)
        {
            var datetime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, timezoneId);
            return new DateTimeDTO(datetime);
        }
    }
}