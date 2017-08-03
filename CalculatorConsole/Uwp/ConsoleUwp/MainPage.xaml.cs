using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ConsoleUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public int Value1 { get { return Int32.Parse(Number1.Text); } }

        public int Value2 { get { return Int32.Parse(Number2.Text); } }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = (Value1 + Value2).ToString();
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = (Value1 / Value2).ToString();
        }
    }
}
