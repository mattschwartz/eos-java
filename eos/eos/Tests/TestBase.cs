using System;
using System.IO;
using eos.Models.Data;
using NUnit.Framework;

namespace eos.Tests
{
    public class TestBase
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var appDataDirectory = Path.Combine(baseDirectory.Replace("\\bin", ""), "App_Data");

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataDirectory);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }
    }
}