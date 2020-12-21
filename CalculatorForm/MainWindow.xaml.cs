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

namespace CalculatorForm
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private resultDisplay _resultDisplay;


        public MainWindow()
        {
            InitializeComponent();
            _resultDisplay = new resultDisplay(ResultDisplayLabel);
            


        }
        private void numberButtonClick(object sender,RoutedEventArgs e)
        {
            var button = sender as Button;
            _resultDisplay.showResult(button.Content.ToString());
        }

        private void decimalPointButtonClick(object sender,RoutedEventArgs e)
        {
            var button = sender as Button;
            _resultDisplay.showDecimalPoint(button.Content.ToString());
        }

        private void clearButtonClick(object sender,RoutedEventArgs e)
        {
            _resultDisplay.clearResult();
        }



        private class resultDisplay
        {
            private Label _resultDisplayLabel;
            private static readonly int _maxResultLength = 16;
            private static readonly string _defaultValue = "0";

                internal resultDisplay(Label label)
            {
                _resultDisplayLabel = label;
            }

            internal void showResult(string inputValue)
            {
                string nowResult = getLabelValue();

                if (nowResult.Length > _maxResultLength) return;

                double result = double.Parse($"{(nowResult == _defaultValue ? string.Empty : nowResult)}{inputValue}");
                //_resultDisplayLabel.Content = string.Format("{0:#,0}", result);
                _resultDisplayLabel.Content = $"{result:#,0.#########}";
            }

            internal void showDecimalPoint(string decimalPoint)
            {
                string nowResult = getLabelValue();
                if (nowResult == _defaultValue || nowResult.Contains(decimalPoint)) return;

                _resultDisplayLabel.Content = $"{nowResult}{decimalPoint}";


            }

            internal void clearResult()
            {
                _resultDisplayLabel.Content = "0";
            }

            private string getLabelValue()
            {
                return _resultDisplayLabel.Content.ToString();
            }


        }


    }
}
