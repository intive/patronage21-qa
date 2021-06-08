using BoDi;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace RestSharpJS.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static RestClient restClient = new RestClient();
        public static IObjectContainer _objectContainer;
        public string envUrl = TestContext.Parameters["entryEndpoint"];

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            if (string.IsNullOrEmpty(envUrl))
                envUrl = "https://localhost:3000/api";

            restClient = new RestClient(envUrl);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<RestClient>(restClient);
        }
    }
}