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
using System.Threading;

namespace PuzzleGamePrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int CurrentSpaceCycle = 0;
        static List<string> SpaceText = new List<string> {
            "Just Press Space", "It's really not hard you know", "Seriously Just Press it Like My God", "Jesus I give up", "....."
        };
        public MainWindow()
        {
            InitializeComponent();
            GameStart();

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && PressSpace.IsVisible == true)
            {
                PressSpace.Visibility = Visibility.Hidden;
                Slider1.Visibility = Visibility.Visible;
                Slider2.Visibility = Visibility.Visible;
                Slider3.Visibility = Visibility.Visible;
                Slider_Checker.Visibility = Visibility.Visible;
                Slider_Hidden_Image.Visibility = Visibility.Visible;
            }
            else if (PressSpace.IsVisible == true)
            {
                if (CurrentSpaceCycle < 5)
                {
                    PressSpace.Text = SpaceText[CurrentSpaceCycle];
                    CurrentSpaceCycle++;
                }
                else
                {
                    PressSpace.Text = PressSpace.Text + ".";
                }
            }

        }

        private void Slider_Checker_Click(object sender, RoutedEventArgs e)
        {
            if (Slider1.Value == 6 && Slider2.Value == 7 && Slider3.Value == 2)
            {
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Found.jpg");
                Slider_Checker.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            }
            else if(Slider_Hidden_Image.Source == (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Hidden.jpg"))
            {
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Wrong Answer.jpg");
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Hidden.jpg");
            }
        }


    }
}
