using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kumojin.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Kumojin.Blazor.Pages
{
    partial class TimeZone : ComponentBase
    {
        [Inject]
        public ITimeZoneService TimeZoneService { get; set; }

        private string tokyoTimezoneId;
        private TimeZoneInfo timeZoneLocal;
        private DateTime currentTime;
        private DateTime currentTimeLocal;

        protected override async Task OnInitializedAsync()
        {
            await ShowTimeZone();
        }

        private async Task ShowTimeZone()
        {
            tokyoTimezoneId = TimeZoneService.GetViewModel().Id;
            timeZoneLocal = TimeZoneInfo.Local;
            currentTimeLocal = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneLocal);

            var dto = await TimeZoneService.GetTimeZone(tokyoTimezoneId);
            currentTime = dto.CurrentTime;
            StateHasChanged();
        }
    }
}