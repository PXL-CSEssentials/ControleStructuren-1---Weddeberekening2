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

namespace ControleStructuren_1___Weddeberekening2
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

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Declaratie van variabelen die we later gebruiken    
            float gross;
            float tax;
            float net;

            // Toekenning aan variabele naam.     
            string name = employeeTextBox.Text;
            float hourlyWage = float.Parse(hourlyWageTextBox.Text);
            short numberOfHours = short.Parse(numberOfHoursTextBox.Text);

            // Berekening     
            gross = numberOfHours * hourlyWage;

            // Belastingsschijven If-structuur     
            if (gross <= 10000)
            {
                // Als je bruto niet meer dan 10000 euro verdient, 0 euro belasting.
                tax = 0;
            }
            else if (gross <= 15000)
            {
                tax = (gross - 10000) * 0.2f;
            }
            else if (gross <= 25000)
            {
                tax = ((gross - 15000) * 0.3f) + 1000;
            }
            else if (gross <= 50000)
            {
                tax = ((gross - 25000) * 0.4f) + 4000;
            }
            else
            {
                tax = ((gross - 50000) * 0.5f) + 14000;
            }

            net = gross - tax;

            // Afdruk met interpolation string of $-string     
            resultTextBox.Text = $"LOONFICHE VAN {name}\r\n\r\n" +
                $"Aantal gewerkte uren : {numberOfHours}\r\n" +
                $"Uurloon : {hourlyWage:c}\r\n" +
                $"Brutojaarwedde : {gross:C}\r\n" +
                $"Belasting : {tax:C} \r\nNettojaarwedde : {net:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            employeeTextBox.Text = string.Empty;
            numberOfHoursTextBox.Text = "0";
            hourlyWageTextBox.Text = "0";
            resultTextBox.Text = string.Empty;

            employeeTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
