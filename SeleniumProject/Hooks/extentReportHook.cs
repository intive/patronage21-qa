using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Hooks
{
    [Binding]
    public sealed class extentReportHook
    {
        private static ScenarioContext _scenarioContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"..\..\..\Reports\");
            _extentHtmlReporter.Config.DocumentTitle = "intive -Patronage 2020/21 QA";
            _extentHtmlReporter.Config.ReportName = "Automation tests - Selenium";
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title,
                   featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title,
                   scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;

                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;

                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;

                default:
                    CreateNode<And>();
                    break;
            }
        }
        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail

                (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
            }
            else
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
    }
}