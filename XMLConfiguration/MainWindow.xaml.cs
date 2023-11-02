using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace XMLConfiguration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            XDocument doc = XDocument.Load("config.xml");

            string foregroundColor = doc.Root!.Element("ForegroundColor")!.Value;
            string backgroundColor = doc.Root!.Element("BackgroundColor")!.Value;

            textContent.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(foregroundColor));
            textContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string? selectedForegroundColor = (cbForegroundOption.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? selectedBackgroundColor = (cbBackgroundOption.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedForegroundColor != null && selectedBackgroundColor != null)
            {
                XDocument doc = XDocument.Load("config.xml");

                doc.Root!.Element("ForegroundColor")!.Value = selectedForegroundColor!;
                doc.Root!.Element("BackgroundColor")!.Value = selectedBackgroundColor!;

                doc.Save("config.xml");

                textContent.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedForegroundColor));
                textContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedBackgroundColor));
            }
        }
    }
}
