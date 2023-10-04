using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lesson3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage[] images;
        int index = 0;

        public MainWindow()
        {
            InitializeComponent();

            var directory = new DirectoryInfo(@"d:\Images");

            var files = directory.GetFiles();

            images = new BitmapImage[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                images[i] = new BitmapImage(new Uri(files[i].FullName));
            }

            PictureBox.Source = images[index];
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (index < images.Length - 1)
                PictureBox.Source = images[++index];
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
                PictureBox.Source = images[--index];
        }
    }
}
