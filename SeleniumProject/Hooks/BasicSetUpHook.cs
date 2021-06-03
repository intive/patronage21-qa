using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace SeleniumProject.Hooks
{
    [Binding]
    public sealed class BasicSetUpHook
    {
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\amida\Documents\Raporty\");
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
        public static void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    break;

                case ScenarioBlock.When:
                    _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    break;

                case ScenarioBlock.Then:
                    _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    break;

                default:
                    _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
    }
}