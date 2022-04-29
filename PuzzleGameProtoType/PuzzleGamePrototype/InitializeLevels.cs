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
using System.Timers;

namespace PuzzleGamePrototype
{
    public partial class MainWindow : Window
    {
        

        public void GameStart()
        {
            Slider1.Visibility = Visibility.Collapsed;
            Slider2.Visibility = Visibility.Collapsed;
            Slider3.Visibility = Visibility.Collapsed;
            Slider_Checker.Visibility = Visibility.Collapsed;
            Slider_Hidden_Image.Visibility = Visibility.Collapsed;
            PressSpace.Visibility = Visibility.Visible;
            ComboRed.Visibility = Visibility.Collapsed;
            ComboGreen.Visibility = Visibility.Collapsed;
            ComboBlue.Visibility = Visibility.Collapsed;
        }
        public void SpacePressed()
        {
            PressSpace.Visibility = Visibility.Collapsed;
            Slider1.Visibility = Visibility.Visible;
            Slider2.Visibility = Visibility.Visible;
            Slider3.Visibility = Visibility.Visible;
            Slider_Checker.Visibility = Visibility.Visible;
            Slider_Hidden_Image.Visibility = Visibility.Visible;
            ComboRed.Visibility = Visibility.Visible;
            ComboGreen.Visibility = Visibility.Visible;
            ComboBlue.Visibility = Visibility.Visible;
        }

    }
}
