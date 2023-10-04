using Lesson8.Models;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using System;

namespace Lesson8.Saver
{
    public static class CoordinateSaver
    {
        private const string Path = "..//..//..//Coordinates.xml";
        private static readonly XmlSerializer serializer;

        static CoordinateSaver() =>
             serializer = new(typeof(Coordinates));

        public static Coordinates GetCoordinates()
        {
            var coordinates = new Coordinates() { Left = 0, Top = 0 };

            try
            {
                using var stream = new FileStream(Path, FileMode.Open);
                return (Coordinates)serializer.Deserialize(stream);
            }
            catch
            {
                return coordinates;
            }
        }

        public static void SaveCoordinates(Coordinates coordinates)
        {
            try
            {
                using var stream = new FileStream(Path, FileMode.Create);
                serializer.Serialize(stream, coordinates);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
