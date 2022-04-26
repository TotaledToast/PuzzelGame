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

namespace PuzzleGamePrototype
{
    public partial class MainWindow : Window
    {
        public void GameStart()
        {
            Slider1.Visibility = Visibility.Hidden;
            Slider2.Visibility = Visibility.Hidden;
            Slider3.Visibility = Visibility.Hidden;
            Slider_Checker.Visibility = Visibility.Hidden;
            Slider_Hidden_Image.Visibility = Visibility.Hidden;
            PressSpace.Visibility = Visibility.Visible;
        }

    }
}
