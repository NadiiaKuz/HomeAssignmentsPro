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
        private readonly string _path = "..//..//..//..//..//Where_the_crawdads_sing.txt";

        private CancellationTokenSource _source;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "Text is loading...";

            _source = new CancellationTokenSource();
            CancellationToken token = _source.Token;

            try
            {
                var content = await File.ReadAllTextAsync(_path, token);
                TextBox.Text = content[..100000];
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException)
                    TextBox.Text = "Load was canceled";
                else
                    TextBox.Text = ex.Message;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) =>
            _source?.Cancel();
    }
}
