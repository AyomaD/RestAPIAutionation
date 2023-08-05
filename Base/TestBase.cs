using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestAPIAutomation.Helper;

namespace RestAPIAutomation.Base
{
    [TestFixture]
    public class TestBase :Base
    {
        protected ObjectHelper objectHelper;
        [SetUp]
        public void StartTest()
        {
            objectHelper = new ObjectHelper();
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void EndTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            Test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

        }
    }
}
