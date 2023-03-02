using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace FileSystemWatcher_WebBrowser_Test
{
    public partial class MainWindow : Window
    {
        FileSystemWatcher fsw = new FileSystemWatcher("c:\\temp");


        public MainWindow()
        {
            InitializeComponent();

            Debug.WriteLine("Constructor");

            fsw.Created += Fsw_Created;
            fsw.EnableRaisingEvents = true;
        }

        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine("Created");

            // https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it
            Dispatcher.Invoke(() =>
            {
                browser.Navigate("https://sirocco.accuweather.com/nx_mosaic_640x480_public/sir/inmsirmi_.gif");
            });
        }

        private void google_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click");

            browser.Navigate("https://www.google.com");
        }
    }
}
