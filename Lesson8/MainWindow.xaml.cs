using Lesson8.Models;
using Lesson8.Saver;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson8
{
    public partial class MainWindow : Window
    {
        private const double Step = 10;
        private Coordinates coordinates;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    MoveLeft();
                    break;
                case Key.Right:
                    MoveRight();
                    break;
                case Key.Up:
                    MoveUp();
                    break;
                case Key.Down:
                    MoveDown();
                    break;
            }
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            var coordinates = new Coordinates()
            {
                Left = Canvas.GetLeft(square),
                Top = Canvas.GetTop(square)
            };

            CoordinateSaver.SaveCoordinates(coordinates);
        }

        #region Movements

        private void MoveLeft()
        {
            var position = Canvas.GetLeft(square) - Step;

            if (position < 0)
                position = 0;

            Canvas.SetLeft(square, position);
        }

        private void MoveRight()
        {
            var position = Canvas.GetLeft(square) + Step;
            if (position > canvas.ActualWidth - square.Width)
                position = canvas.ActualWidth - square.Width;

            Canvas.SetLeft(square, position);
        }

        private void MoveUp()
        {
            var position = Canvas.GetTop(square) - Step;

            if (position < 0)
                position = 0;

            Canvas.SetTop(square, position);
        }

        private void MoveDown()
        {
            var position = Canvas.GetTop(square) + Step;

            if (position > canvas.ActualHeight - square.Height)
                position = canvas.ActualHeight - square.Height;

            Canvas.SetTop(square, position);
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coordinates = CoordinateSaver.GetCoordinates();
            Canvas.SetLeft(square, coordinates.Left);
            Canvas.SetTop(square, coordinates.Top);
        }
    }
}