using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoinmarketcapScreenShot
{
    public partial class FrmMain : Form
    {
        public static string FolderUserData = Path.Combine(Application.StartupPath, "ChromeUserData");
        public static string SettingCoinFile = Path.Combine(Application.StartupPath, "setting_coins.txt");

        public static ChromeDriver driver = null;
        public static ReadOnlyCollection<IWebElement> elements = null;
        public static IWebElement element = null;
        public static Actions actions = null;
        public static IJavaScriptExecutor js;

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dateTimeClock.Format = DateTimePickerFormat.Custom;
            dateTimeClock.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimeClock.Value = DateTime.Today;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = ".\\runtimes\\win\\native\\selenium-manager.exe";
            pc_chrome.StartInfo.Arguments = "--browser chrome";
            pc_chrome.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pc_chrome.Start();
            pc_chrome.WaitForExit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void StartChromeDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();

            options.AddArgument($"--user-data-dir={FolderUserData}");

            options.AddArgument("--start-maximized");
            //options.AddArgument("--disable-notifications");
            //options.AddArgument("--disable-infobars");
            //options.AddArgument("--disable-popup-blocking");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Undetected webdriver
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddExcludedArguments(new List<string>() { "enable-automation" });
            options.AddAdditionalChromeOption("useAutomationExtension", false);

            driver = new ChromeDriver(service, options);

            js = (IJavaScriptExecutor)driver;
            actions = new Actions(driver);
        }

        private void CloseChromeDriver()
        {
            try
            {
                driver.Navigate().GoToUrl("chrome://downloads");
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
            try
            {
                driver.Quit();
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void buttonOpenProfile_Click(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = "chrome.exe";
            pc_chrome.StartInfo.Arguments = $"https://coinmarketcap.com --start-maximized --user-data-dir={FolderUserData}";
            pc_chrome.Start();
        }

        private void buttonOpenDriver_Click(object sender, EventArgs e)
        {
            StartChromeDriver();
            for (int i = 0; i < 60 * 60; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    driver.FindElement(By.CssSelector("body, div"));
                }
                catch (Exception)
                {
                    break;
                }
            }
            driver.Quit();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<string> listUrls = File.ReadAllLines(SettingCoinFile, Encoding.UTF8).ToList();

            string coinName = string.Empty;

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            foreach (var linkCoin in listUrls)
            {
                try
                {
                    // move mouse
                    Cursor.Position = new Point(0, 0);

                    driver.Navigate().GoToUrl(linkCoin);
                    Thread.Sleep(1500);

                    // coin name
                    coinName = driver.FindElement(By.CssSelector("#section-coin-overview span[data-role='coin-symbol']")).Text.Trim();

                    // chose time
                    if (radio7day.Checked)
                    {
                        driver.FindElement(By.CssSelector("ul li[data-index='tab-7D']")).Click();
                    }

                    if (radio1month.Checked)
                    {
                        driver.FindElement(By.CssSelector("ul li[data-index='tab-1M']")).Click();
                    }

                    if (radio1year.Checked)
                    {
                        driver.FindElement(By.CssSelector("ul li[data-index='tab-1Y']")).Click();
                    }

                    Thread.Sleep(1000);

                    // xóa header
                    js.ExecuteScript("document.querySelector('div[data-role=\"global-header\"], div[data-test=\"global-header\"]').remove()");
                    js.ExecuteScript("if (document.querySelector('div.chart-control-left')) document.querySelector('div.chart-control-left').remove()");
                    js.ExecuteScript("if (document.querySelector('div[data-role=\"select-trigger\"]')) document.querySelector('div[data-role=\"select-trigger\"]').remove()");
                    js.ExecuteScript("if (document.querySelector('li[data-index=\"tab-6\"]')) document.querySelector('li[data-index=\"tab-6\"]').remove()");
                    js.ExecuteScript("if (document.querySelector('li[data-index=\"tab-8\"]')) document.querySelector('li[data-index=\"tab-8\"]').remove()");
                    Thread.Sleep(100);

                    // scroll to chart
                    element = driver.FindElement(By.CssSelector("svg.highcharts-root"));
                    js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
                    Thread.Sleep(500);

                    // neu la chu nhat se up chart 7 ngay
                    if (radio7day.Checked)
                    {
                        try
                        {
                            // save
                            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                            int weekNumber = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                            string saveFolder = Path.Combine(Application.StartupPath, $"weeks{weekNumber}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} w{weekNumber} {DateTime.Now.ToString("yyyy-MM-dd")}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            // element chart
                            element = driver.FindElement(By.CssSelector("svg.highcharts-root"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X, element.Location.Y - 45, element.Size.Width - 3, element.Size.Height - 95 + 45);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 7 day: {ex.Message}\n");
                        }
                    }

                    // neu la ngay cuoi thang se up chart 1 thang
                    if (radio1month.Checked)
                    {
                        try
                        {
                            // save
                            string saveFolder = Path.Combine(Application.StartupPath, $"months{DateTime.Now.Month}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.ToString("yyyy-MM")}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            // element chart
                            element = driver.FindElement(By.CssSelector("svg.highcharts-root"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X, element.Location.Y - 45, element.Size.Width - 3, element.Size.Height - 95 + 45);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 1 month: {ex.Message}\n");
                        }
                    }

                    // neu la ngay cuoi nam se up chart 1 nam
                    if (radio1year.Checked)
                    {
                        try
                        {
                            // save
                            string saveFolder = Path.Combine(Application.StartupPath, $"years{DateTime.Now.Year}");
                            string imgFileName = Path.Combine(saveFolder, $"{coinName} {DateTime.Now.Year}.png");
                            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                            if (checkSkipCoinExistImage.Checked && File.Exists(imgFileName))
                            {
                                throw new Exception("Skip exist");
                            }

                            // element chart
                            element = driver.FindElement(By.CssSelector("svg.highcharts-root"));

                            // screen shot
                            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                            Bitmap bmimg = Image.FromStream(new System.IO.MemoryStream(sc.AsByteArray)) as Bitmap;
                            Rectangle cropArea = new Rectangle(element.Location.X, element.Location.Y - 45, element.Size.Width - 3, element.Size.Height - 95 + 45);
                            bmimg = bmimg.Clone(cropArea, bmimg.PixelFormat);
                            bmimg.Save(imgFileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("error.txt", $"{coinName} - 1 year: {ex.Message}\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText("error.txt", $"{coinName}: {ex.Message}\n");
                }
            }

            // quit
            CloseChromeDriver();

            SystemSounds.Asterisk.Play();

            // shutdown computer
            if (checkShutdownAfterFinish.Checked) shutdown();

            // exit application
            if (checkExitApp.Checked) Application.Exit();
        }

        private void buttonFastSet_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dateTimeClock.Value = new DateTime(today.Year, today.Month, today.Day, 23, 50, today.Second);
            System.Media.SystemSounds.Hand.Play();
        }

        private void dateTimeClock_ValueChanged(object sender, EventArgs e)
        {
            timerClock.Enabled = true;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            string timeNow = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            string timeSet = dateTimeClock.Value.ToString("dd-MM-yyyy HH:mm");

            if (dateTimeClock.Value.Hour == 0 && dateTimeClock.Value.Minute == 0)
            {
                timerClock.Enabled = false;
                return;
            }

            labelMsg.Text = timeNow;

            if (DateTime.Now.Second % 2 == 0)
            {
                labelMsg.Font = new Font("Arial", 9, FontStyle.Regular);
            }
            else
            {
                labelMsg.Font = new Font("Arial", 9, FontStyle.Bold);
            }

            if (timeNow == timeSet)
            {
                timerClock.Enabled = false;
                buttonStart_Click(null, null);
            }
        }
        private void shutdown()
        {
            Process sd_proc = Process.Start("shutdown.exe", "-s -t 0");
            sd_proc.WaitForExit();
        }

        private void buttonScanTopList_Click(object sender, EventArgs e)
        {
            List<string> listCoinUrl = new List<string>();

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            driver.Navigate().GoToUrl("https://coinmarketcap.com");
            Thread.Sleep(2000);

            element = driver.FindElement(By.CssSelector("[data-role='select-trigger']"));

            // hover
            js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
            Thread.Sleep(500);
            actions.MoveToElement(element).MoveByOffset(1, 1).Perform();
            Thread.Sleep(500);

            // scan list
            elements = driver.FindElements(By.CssSelector("table tbody tr td div[display='flex'] a.cmc-link"));
            foreach (var element in elements)
            {
                string coinUrl = element.GetAttribute("href");
                if (string.IsNullOrEmpty(coinUrl))
                {
                    continue;
                }
                listCoinUrl.Add(coinUrl);
            }

            File.WriteAllLines(SettingCoinFile, listCoinUrl, Encoding.UTF8);

            driver.Quit();
        }
    }
}
