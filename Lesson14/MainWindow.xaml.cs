using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Path = "..//..//..//..//..//Where_the_crawdads_sing.txt";

        private CancellationTokenSource _source;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = String.Empty;

            _source = new CancellationTokenSource();
            CancellationToken token = _source.Token;

            try
            {

                using (StreamReader reader = new(Path))
                {
                    char[] buffer = new char[1024];
                    int read;

                    while ((read = await reader.ReadAsync(buffer, token)) > 0)
                    {
                        TextBox.AppendText(new string(buffer, 0, read));

                        await Task.Delay(100);
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                if (ex is TaskCanceledException)
                    message = "Load was canceled";

                MessageBox.Show(message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) =>
            _source?.Cancel();
    }
}
