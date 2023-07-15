using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkingPermitGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.textBlockYear.Text = DateTime.Now.Year.ToString();
            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            monthNames.Where(m => !string.IsNullOrWhiteSpace(m)).Select(m => char.ToUpper(m[0]) + m[1..]).Select(m => this.comboBoxMounth.Items.Add(m)).ToArray();
            this.comboBoxMounth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void buttonsYear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int year = int.Parse(this.textBlockYear.Text);
                year = sender switch
                {
                    RepeatButton { Content: "<" } => --year,
                    RepeatButton { Content: ">" } => ++year,
                    _ => throw new Exception("Неизвестная функция над числом")
                };
                this.textBlockYear.Text = year.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
