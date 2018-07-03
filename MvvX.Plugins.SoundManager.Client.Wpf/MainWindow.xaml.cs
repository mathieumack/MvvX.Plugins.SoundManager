using MahApps.Metro.Controls;
using MvvX.Plugins.SoundManager.Wpf;
using System.Timers;
using System.Windows;

namespace MvvX.Plugins.SoundManager.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly IAudioManager manager;
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            this.manager = new AudioManager();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // We start a timer to check every 2 seconds the state of the sound on the computer :
            timer = new Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => {
                var mastervolume = manager.GetMasterVolume();
                if ((double)sliderVolume.Value != mastervolume)
                    sliderVolume.Value = manager.GetMasterVolume();
                Soundvolumevalue.Text = mastervolume.ToString();
                SoundMute.IsChecked = manager.GetMasterVolumeMute();
            });
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            manager.SetMasterVolume((float)sliderVolume.Value);
        }

        private void SoundMute_Checked(object sender, RoutedEventArgs e)
        {
            if (!manager.GetMasterVolumeMute())
            {
                manager.SetMasterVolumeMute(true);
            }
            else
                e.Handled = true;
        }

        private void SoundMute_Unchecked(object sender, RoutedEventArgs e)
        {
            if (manager.GetMasterVolumeMute())
            {
                manager.SetMasterVolumeMute(false);
            }
            else
                e.Handled = true;
        }
    }
}
