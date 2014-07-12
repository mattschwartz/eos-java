using System;
using System.Data.Entity;
using System.IO;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;
using Ionic.Zip;
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

            var zipPath = Path.Combine(appDataDirectory, "eos-data.zip");
            var dataPath = Path.Combine(appDataDirectory, "eos.mdf");

            if (!File.Exists(dataPath)) {
                using (var zip = ZipFile.Read(zipPath)) {
                    zip.ExtractAll(appDataDirectory, ExtractExistingFileAction.DoNotOverwrite);
                }
            }

            DataContext.ConnectionStringName = "Test";

            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());

            var context = new DataContext();
            User.Seed(context);
            Subject.Seed(context);
            Task.Seed(context);
            //Document.Seed(this);
            CalendarEvent.Seed(context);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }
    }
}