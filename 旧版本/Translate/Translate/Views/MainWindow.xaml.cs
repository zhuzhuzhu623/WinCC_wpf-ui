using GM.BLLModel;
using GM.Enums;
using GM.Translate;
using MahApps.Metro.Controls;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Translate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
        }
        BaiduTranslate BaiduTranslate = new BaiduTranslate();   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type enumType = typeof(EmLanguageType);
            Array enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                EmLanguageType result = (EmLanguageType)Enum.Parse(typeof(EmLanguageType), value.ToString());
                var des = typeof(EmLanguageType).GetDescriptionString((int)result);
                cbxFrom.Items.Add(des);
            }
            cbxFrom.SelectedIndex = 0;
            enumType = typeof(EmLanguageType);
            enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                EmLanguageType result = (EmLanguageType)Enum.Parse(typeof(EmLanguageType), value.ToString());
                var des = typeof(EmLanguageType).GetDescriptionString((int)result);
                cbxTo.Items.Add(des);
            }
            cbxTo.SelectedIndex = 1;
        }

        private void btnTranslate_Click(object sender, RoutedEventArgs e)
        {
            FlieText flieText = new FlieText();
            flieText.Context = txtInput.Text; 
            flieText.From = cbxFrom.SelectedIndex;
            flieText.To = cbxTo.SelectedIndex;
            flieText.ResultContext = BaiduTranslate.GetContext(flieText);
            txtResult.Text = flieText.ResultContext;    
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            txtResult.Text ="";
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            FlieText flieText = new FlieText();
            flieText.Context = txtInput.Text;
            flieText.From = cbxFrom.SelectedIndex;
            flieText.To = cbxTo.SelectedIndex;
            Task.Run(() => { 
                flieText.ResultContext = BaiduTranslate.GetContext(flieText); 
                this.BeginInvoke(new Action(() => { txtResult.Text = flieText.ResultContext;   }));
            });

        }

        private void cbxTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxTo.SelectedIndex == 0)
            {
                txtResult.FontFamily = new FontFamily("楷体");
             }
            else
            {
                txtResult.FontFamily = new FontFamily("Arial");
            }
        }

        private void cbxFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTo.SelectedIndex == 0)
            {
                txtResult.FontFamily = new FontFamily("楷体");
            }
            else
            {
                txtResult.FontFamily = new FontFamily("Arial");
            }
        }
    }
}