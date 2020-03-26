using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;
using System.Threading.Tasks;
using Windows.System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WaterTankController
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GpioPin alarm;
        public MainPage()
        {            
            this.InitializeComponent();
            Loaded += MainPage_Load;
            ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Shutdown, TimeSpan.FromSeconds(1));
        }
        private void MainPage_Load(object sender, RoutedEventArgs e)
        {
            var controller = GpioController.GetDefault();            
            alarm = controller.OpenPin(26);           
            alarm.SetDriveMode(GpioPinDriveMode.Output);
            alarm.Write(GpioPinValue.Low);
            Task.Delay(787000).Wait();
            alarm.Write(GpioPinValue.High);            
        }
    }
}
