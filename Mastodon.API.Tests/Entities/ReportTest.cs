﻿using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ReportTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_report.json");
            var actual = JsonConvert.DeserializeObject<Report>(jsonString);
            var expected = new Report("101", true);
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
