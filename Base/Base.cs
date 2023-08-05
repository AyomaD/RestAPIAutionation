using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace RestAPIAutomation.Base
{
    [SetUpFixture]
    public class Base
    {
        protected ExtentReports Extent;
        protected ExtentTest Test;

        [OneTimeSetUp]
        protected void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            Extent.Flush();
        }

    }
}
