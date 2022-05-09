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

        private void Border_Button_Click(object sender, RoutedEventArgs e)
        {
            NativeMethods.SetCursorPos(Convert.ToInt32(GetWindowLeft(GameWindow)) + 195, Convert.ToInt32(GetWindowTop(GameWindow)) + 70);
        }

        private void Border_Click_Button_Click(object sender, RoutedEventArgs e)
        {
            Border_Button_1.Content = "2194";
        }

        private void Colour_Guess_Start_Click(object sender, RoutedEventArgs e)
        {
            Colour_Guess_Start_1();
        }

        private void Colour_Button_Click(object sender, RoutedEventArgs e)
        {
            List<char> PressOrder = new List<char>
            {
                '3','6','8','1','5','4','2','9','7','3','1','5'
            };
            if (((Button)sender).Tag.ToString() == PressOrder[Convert.ToInt32(Colour_Guess_Start.Tag.ToString())].ToString())
            {
                Colour_Guess_Start.Tag = ((Convert.ToInt32(Colour_Guess_Start.Tag.ToString())) + 1).ToString();
                if (Colour_Guess_Start.Tag.ToString() == "12")
                {
                    Colour_Guess_Start.Content = "3249";
                    Colour_Click_1.IsEnabled = false;
                    Colour_Click_2.IsEnabled = false;
                    Colour_Click_3.IsEnabled = false;
                    Colour_Click_4.IsEnabled = false;
                    Colour_Click_5.IsEnabled = false;
                    Colour_Click_6.IsEnabled = false;
                    Colour_Click_7.IsEnabled = false;
                    Colour_Click_8.IsEnabled = false;
                    Colour_Click_9.IsEnabled = false;
                    Colour_Guess_Start.IsEnabled = false;

                }
            }
            else
            {
                Colour_Guess_Start.Tag = "0";
                Colour_Guess_Start.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE03217");
                Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => { Colour_Guess_Start.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FDDDDDDD"); }));
            }

        }

        private void CPS_Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "0")
            {
                ((Button)sender).Tag = "1";
                Task.Delay(1000).ContinueWith(a => this.Dispatcher.Invoke(() => { CPS_Button.IsEnabled = false;
                if (Convert.ToInt32(((Button)sender).Tag.ToString()) >= 12)
                {
                    CPS_Button.Content = "672";
                }
                else
                {
                    CPS_Button.Content = "Try Again";
                        ((Button)sender).Tag = "0";
                    Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => {
                        CPS_Button.IsEnabled = true;
                        CPS_Button.Content = "Click Me Fast!";
                    }));
                }
                }));
            }
            else
            {
                ((Button)sender).Tag = (Convert.ToInt32(((Button)sender).Tag.ToString()) + 1).ToString();
            }
        }

        private void Type_Race_Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE03217");
            Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFDB230"); }));
            Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFF4FD30"); }));
            Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2EE810"); }));

        }
    }
}
