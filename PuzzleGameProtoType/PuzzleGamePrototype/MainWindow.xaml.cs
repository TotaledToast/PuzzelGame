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
using System.Timers;

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
                SpacePressed();
                GameWindow.Title = "RGB";
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
                Slider_Checker.Tag = "Clicked";
            }
            else if(Slider_Checker.Tag.ToString() == "NotClicked")
            {
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Wrong Answer.jpg");
                Task.Delay(450).ContinueWith(t => this.Dispatcher.Invoke(() => { Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Hidden.jpg"); }));
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(ComboRed.SelectedIndex) == 2 && Convert.ToInt32(ComboGreen.SelectedIndex) == 4 && Convert.ToInt32(ComboBlue.SelectedIndex) == 5)
            {
                RGBComboAnswer.Visibility = Visibility.Visible;
                GameWindow.Title = "PuzzleGame";
                ComboRed.IsEnabled = false;
                ComboGreen.IsEnabled = false;
                ComboBlue.IsEnabled = false;
            }
        }
    }
}
