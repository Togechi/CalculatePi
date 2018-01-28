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
using Xceed.Wpf.Toolkit;
using System.Runtime.InteropServices;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int startStopMode = 1;
        decimal pi = 3m;
        int iterations;

        public MainWindow()
        {
            InitializeComponent();
            ResetTexts();
        }

        private void DisplayPi()
        {
            outputBox.Text += pi.ToString() + "\r\n";
        }

        private void ResetTexts()
        {
            outputBox.Text = string.Empty;
            iterationsInput.Text = 1.ToString();
            StartStopChangeMode(1);
        }

        private void StartStopChangeMode(int mode)
        {
            if (mode == 1)
            {
                startStopMode = 1;
            }

            if (mode == 2)
            {
                startStopMode = 2;
            }

            if (mode == 0)
            {
                if (startStopMode == 1)
                {
                    startStopMode = 2;
                }
                else if (startStopMode == 2)
                {
                    startStopMode = 1;
                }
            }

            if (startStopMode == 1)
            {
                startStopButton.Content = "Calculate";
            }
            else if (startStopMode == 2)
            {
                pi = 3;
                startStopButton.Content = "Stop";
            }
        }

        private void startStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (startStopMode == 1)
            {
                // Start calculation
                StartStopChangeMode(0);
                if (CheckAndSetIterations())
                    CalculatePi();
            }
            else if (startStopMode == 2)
            {
                StartStopChangeMode(0);
            }
        }

        private bool CheckAndSetIterations()
        {
            int p;


            if (Int32.TryParse(iterationsInput.Text, out p))
            {
                iterations = p;
                outputBox.Text = string.Empty;
                return true;
            }
            else
            {
                StartStopChangeMode(1);
                outputBox.Text = "Error 00A: Invalid amount of iterations" + "\r\n";
                outputBox.Text += "(Hint: Only use integer characters in input box)";
                return false;
            }
        }

        private void CalculatePi()
        {
            int z = 1;
            //pi = pi + 4m / (2m * 3m * 4m) - 4m / (5m * 6m * 7m);

            for (int i = 2; i <= (2+((iterations-1)*4)); i+=4) 
            {
                decimal di = (decimal)i;
                pi = pi + (4m / ((di) * (di + 1m) * (di + 2m)));
                pi = pi - (4m / ((di+2m) * (di + 3m) * (di + 4m)));
                DisplayPi();

                /*decimal tdi = di + 4m;
                pi = pi + (4m / ((tdi) * (tdi + 1m) * (tdi + 2m)));
                pi = pi - (4m / ((tdi + 2m) * (tdi + 3m) * (tdi + 4m)));
                DisplayPi();

                decimal tpi;
                tpi = 3m + 4m / (2m * 3m * 4m);
                tpi = tpi - 4m / (4m * 5m * 6m);
                tpi = tpi + 4m / (6m * 7m * 8m);
                tpi = tpi - 4m / (8m * 9m * 10m);
                outputBox.Text += tpi.ToString() + " "; */
            }

            StartStopChangeMode(0);
        }

        private void iterationsInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void outputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputBox.SelectionStart = outputBox.Text.Length;
            outputBox.ScrollToEnd();
        }

    }

}
