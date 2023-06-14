using LearningSelenium.Utils;
using OpenQA.Selenium;
using System.Text;

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
            var networkConditions = new OpenQA.Selenium.DevTools.V110.Network.EmulateNetworkConditionsCommandSettings
            {
                DownloadThroughput = 10000
            };

            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V110.DevToolsSessionDomains>()
                .Network
                .EmulateNetworkConditions(networkConditions);

            GetDriver().Navigate().GoToUrl("https://www.selenium.dev");
        }

        [Test]
        public async Task EmulateGeolocationTest()
        {
            var geolocation = new OpenQA.Selenium.DevTools.V110.Emulation.SetGeolocationOverrideCommandSettings
            {
                Latitude = 51.509865,
                Longitude = -0.118092,
                Accuracy = 1
            };

            await session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V110.DevToolsSessionDomains>()
                .Emulation
                .SetGeolocationOverride(geolocation);

            GetDriver().Navigate().GoToUrl("https://maps.google.com");
            var element = new Wait(GetDriver())
                .WaitForTheElementToBecomeVisible(By.CssSelector("#mylocation #sVuEFc"), TimeSpan.FromSeconds(10));
            element.Click();

            Thread.Sleep(10000);
        }

        [Test]
        public async Task InterceptNetworkRequestsTest()
        {
            var fetch = session.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V110.DevToolsSessionDomains>()
                .Fetch;

            var enableCommandSettings = new OpenQA.Selenium.DevTools.V110.Fetch.EnableCommandSettings();

            var requestPattern = new OpenQA.Selenium.DevTools.V110.Fetch.RequestPattern
            {
                RequestStage = OpenQA.Selenium.DevTools.V110.Fetch.RequestStage.Request,
                ResourceType = OpenQA.Selenium.DevTools.V110.Network.ResourceType.XHR,
                UrlPattern = "*/workshops.json"
            };

            enableCommandSettings.Patterns = new OpenQA.Selenium.DevTools.V110.Fetch.RequestPattern[] { requestPattern };

            await fetch.Enable(enableCommandSettings);

            async void requestIntercepted(object sender, OpenQA.Selenium.DevTools.V110.Fetch.RequestPausedEventArgs e)
            {
                await fetch.FulfillRequest(new OpenQA.Selenium.DevTools.V110.Fetch.FulfillRequestCommandSettings()
                {
                    RequestId = e.RequestId,
                    Body = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    """
                    [
                        { "id": 1, "name": "Workshop 1", "price": 400, "checked": false },
                        { "id": 2, "name": "Workshop 2", "price": 200, "checked": false },
                        { "id": 3, "name": "Workshop 3", "price": 300, "checked": false }
                    ]
                    """)),
                    ResponseCode = 200
                });
            }

            fetch.RequestPaused += requestIntercepted;

            GetDriver().Navigate().GoToUrl("http://localhost:4200");

            Thread.Sleep(10000);
        }
    }
}
