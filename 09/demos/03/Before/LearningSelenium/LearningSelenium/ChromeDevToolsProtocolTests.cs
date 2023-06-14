namespace LearningSelenium
{
    internal class ChromeDevToolsProtocolTests : BaseTest
    {
        private OpenQA.Selenium.DevTools.IDevToolsSession session;

        [SetUp]
        public override void SetUp()
        {
            SetDriver(CreateDriver(ConfigurationProvider.Configuration["browser"]));
            var devTools = GetDriver() as OpenQA.Selenium.DevTools.IDevTools;
            session = devTools.GetDevToolsSession();
        }

        [Test]
        public async Task EmulateDeviceModeTest()
        {
            var deviceModeSetting = new OpenQA.Selenium.DevTools.V110.Emulation.SetDeviceMetricsOverrideCommandSettings
            {
                Width = 400,
                Height = 600,
                DeviceScaleFactor = 2,
                Mobile = true
            };

            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V110.DevToolsSessionDomains>()
                  .Emulation
                  .SetDeviceMetricsOverride(deviceModeSetting);

            GetDriver().Navigate().GoToUrl("http://localhost:4200");

            Thread.Sleep(5000);
        }

        [Test]
        public async Task EmulateNetworkConditionsTest()
        {

        }
    }
}
