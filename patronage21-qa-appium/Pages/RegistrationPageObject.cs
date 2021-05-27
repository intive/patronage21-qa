using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Pages
{
    public class RegistrationPageObject
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        public RegistrationPageObject(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public void SelectCheckbox(int instanceNumber)
        {
            var checkBox = _driver.FindElement(
                                   new ByAndroidUIAutomator(
                                       "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                       ".scrollIntoView(new UiSelector().className(\"android.widget.CheckBox\")" +
                                       ".instance(" + instanceNumber + "))"));
            checkBox.Click();
        }

        public void FillEditText(string[] editTextElement, string data)
        {
            var editText = _driver.FindElement(
                              new ByAndroidUIAutomator(
                                  "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                  ".scrollIntoView(new UiSelector().text(\"" + editTextElement[0] + "\"))"));
            editText.Click();
            editText = _driver.FindElement(
                          new ByAndroidUIAutomator(
                              "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                              ".scrollIntoView(new UiSelector().text(\"" + editTextElement[1] + "\"))"));
            editText.SendKeys(data);
        }
    }
}
