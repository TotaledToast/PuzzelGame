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
            Border_Button_1.Visibility = Visibility.Collapsed;
            Border_Button_2.Visibility = Visibility.Collapsed;
            Border_Button_3.Visibility = Visibility.Collapsed;
            Border_Button_4.Visibility = Visibility.Collapsed;
            Border_Button_5.Visibility = Visibility.Collapsed;
            Border_Button_6.Visibility = Visibility.Collapsed;
            Border_Button_7.Visibility = Visibility.Collapsed;
            Border_Click_Button.Visibility = Visibility.Collapsed;
            _1st_Stage_Master_Answer.Visibility = Visibility.Collapsed;
            Colour_Click_1.Visibility = Visibility.Collapsed;
            Colour_Click_2.Visibility = Visibility.Collapsed;
            Colour_Click_3.Visibility = Visibility.Collapsed;
            Colour_Click_4.Visibility = Visibility.Collapsed;
            Colour_Click_5.Visibility = Visibility.Collapsed;
            Colour_Click_6.Visibility = Visibility.Collapsed;
            Colour_Click_7.Visibility = Visibility.Collapsed;
            Colour_Click_8.Visibility = Visibility.Collapsed;
            Colour_Click_9.Visibility = Visibility.Collapsed;
            Colour_Guess_Start.Visibility = Visibility.Collapsed;
            CPS_Button.Visibility = Visibility.Collapsed;
        }
        public void SpacePressed()
        {
            NativeMethods.SetCursorPos(Convert.ToInt32(GetWindowLeft(GameWindow)) + 400, Convert.ToInt32(GetWindowTop(GameWindow)) + 50);
            PressSpace.Visibility = Visibility.Collapsed;
            Slider1.Visibility = Visibility.Visible;
            Slider2.Visibility = Visibility.Visible;
            Slider3.Visibility = Visibility.Visible;
            Slider_Checker.Visibility = Visibility.Visible;
            Slider_Hidden_Image.Visibility = Visibility.Visible;
            ComboRed.Visibility = Visibility.Visible;
            ComboGreen.Visibility = Visibility.Visible;
            ComboBlue.Visibility = Visibility.Visible;
            Border_Button_1.Visibility = Visibility.Visible;
            Border_Button_2.Visibility = Visibility.Visible;
            Border_Button_3.Visibility = Visibility.Visible;
            Border_Button_4.Visibility = Visibility.Visible;
            Border_Button_5.Visibility = Visibility.Visible;
            Border_Button_6.Visibility = Visibility.Visible;
            Border_Button_7.Visibility = Visibility.Visible;
            Border_Click_Button.Visibility = Visibility.Visible;
            _1st_Stage_Master_Answer.Visibility = Visibility.Visible;
            Colour_Click_1.Visibility = Visibility.Visible;
            Colour_Click_2.Visibility = Visibility.Visible;
            Colour_Click_3.Visibility = Visibility.Visible;
            Colour_Click_4.Visibility = Visibility.Visible;
            Colour_Click_5.Visibility = Visibility.Visible;
            Colour_Click_6.Visibility = Visibility.Visible;
            Colour_Click_7.Visibility = Visibility.Visible;
            Colour_Click_8.Visibility = Visibility.Visible;
            Colour_Click_9.Visibility = Visibility.Visible;
            Colour_Guess_Start.Visibility = Visibility.Visible;
            CPS_Button.Visibility = Visibility.Visible;
        }
        public partial class NativeMethods
        {
            /// Return Type: BOOL->int  
            ///X: int  
            ///Y: int  
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }
        private double GetWindowLeft(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var leftField = typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)leftField.GetValue(window);
            }
            else
                return window.Left;
        }
        private double GetWindowTop(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var TopField = typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)TopField.GetValue(window);
            }
            else
                return window.Top;
        }
        private void Colour_Guess_Start_1()
        {
            Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(450).ContinueWith(a => this.Dispatcher.Invoke(() => {
                Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_6.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(450).ContinueWith(b => this.Dispatcher.Invoke(() => {
                    Colour_Click_6.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_8.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(450).ContinueWith(c => this.Dispatcher.Invoke(() => {
                        Colour_Click_8.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(450).ContinueWith(d => this.Dispatcher.Invoke(() => { Colour_Guess_Start_2(); }));
                    }));
                }));
            }));
        }
        private void Colour_Guess_Start_2()
        {
            Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
            Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(450).ContinueWith(f => this.Dispatcher.Invoke(() => {
                Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_4.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(450).ContinueWith(g => this.Dispatcher.Invoke(() => {
                    Colour_Click_4.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_2.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(450).ContinueWith(h => this.Dispatcher.Invoke(() => {
                        Colour_Click_2.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_9.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(450).ContinueWith(i => this.Dispatcher.Invoke(() => { Colour_Guess_Start_3(); }));
                    }));
                }));
            }));
        }
        private void Colour_Guess_Start_3()
        {
            Colour_Click_9.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
            Colour_Click_7.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(450).ContinueWith(j => this.Dispatcher.Invoke(() => {
                Colour_Click_7.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(450).ContinueWith(k => this.Dispatcher.Invoke(() => {
                    Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(450).ContinueWith(l => this.Dispatcher.Invoke(() => {
                        Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(450).ContinueWith(m => this.Dispatcher.Invoke(() => {
                            Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        }));
                    }));
                }));
            }));
        }

    }
}
