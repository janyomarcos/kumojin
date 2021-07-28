using System;
using Newtonsoft.Json;

namespace Kumojin.Blazor.Data
{
    public class DateTimeDTO
    {
        [JsonProperty("currentTime")]
        public DateTime CurrentTime { get; set; }
    }
}