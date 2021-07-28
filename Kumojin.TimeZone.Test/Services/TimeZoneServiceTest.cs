using System;
using Kumojin.Timezone.Data;
using Kumojin.Timezone.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kumojin.TimeZone.Test.Services
{
    [TestClass]
    public class TimeZoneServicesTest
    {
        private string _timezoneId;
        private DateTimeDTO _dto;

        [TestMethod]
        public void TestGetCurrentTime()
        {
            // Arrange
            _timezoneId = "Tokyo Standard Time";

            // Act
            _dto = TimeZoneService.GetDateTimeDTO(_timezoneId);

            // Assert
            Assert.IsNotNull(_dto);
            Assert.IsTrue(_dto.CurrentTime > DateTime.MinValue);
            Assert.IsTrue(_dto.CurrentTime < DateTime.MaxValue);
        }
    }
}