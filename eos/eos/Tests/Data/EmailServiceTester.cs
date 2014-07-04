using System;
using NUnit.Core;
using NUnit.Framework;

namespace eos.Tests.Data
{
    [TestFixture]
    public class EmailServiceTester : TestBase
    {
        [Test]
        public void SendEmail()
        {
            try {
                Services.EmailService.SendMail("project.eos.devteam.com", "subject", "body");
            } catch (Exception ex) {
                Assert.Fail(ex.ToString());
            }
        }
    }
}