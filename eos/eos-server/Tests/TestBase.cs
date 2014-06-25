using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Aztec.Data.Data;
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

            DataContext.Setup();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }
    }
}