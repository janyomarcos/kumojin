using System;
using Kumojin.Timezone.Data;
using Kumojin.Timezone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();
builder.Services.AddCors();

await using var app = builder.Build();

app.UseCors(options => options.WithOrigins(new[] {"https://localhost:48200"}).AllowAnyMethod());

app.MapGet("/timezone", (Func<string, DateTimeDTO>)((string timezoneId) => TimeZoneService.GetDateTimeDTO(timezoneId)));

await app.RunAsync();