using System;
using System.Threading.Tasks;
using Kumojin.Blazor.Data;

namespace Kumojin.Blazor.Services
{
    public interface ITimeZoneService
    {
        Task<DateTimeDTO> GetTimeZone(string timezoneId);
    }
}
