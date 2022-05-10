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
            PressSpace.Visibility = Visibility.Visible;
            _1st_Stage_Master_Answer.Visibility = Visibility.Collapsed;
            Sliders_Load_Unload("Unload");
            ComboBoxes_Load_Unload("Unload");
            MouseMaze_Load_Unload("Unload");
            ColourClicker_load_Unload("Unload");
            CPS_Button.Visibility = Visibility.Collapsed;
            TypeRacer_Load_Unload("Unload");
        } //Loads assets for the start of the game. Mostly Backup UnLoading
        public void SpacePressed()
        {
            NativeMethods.SetCursorPos(Convert.ToInt32(GetWindowLeft(GameWindow)) + 400, Convert.ToInt32(GetWindowTop(GameWindow)) + 50);
            PressSpace.Visibility = Visibility.Collapsed;
            _1st_Stage_Master_Answer.Visibility = Visibility.Visible;
            Sliders_Load_Unload("Load");
            ComboBoxes_Load_Unload("Load");
            MouseMaze_Load_Unload("Load");
            ColourClicker_load_Unload("Load");
            CPS_Button.Visibility = Visibility.Visible;
            TypeRacer_Load_Unload("Load");
        } // Loads all assets for after the space if pressed.

        //All Different Loading Code For Different Puzzles
        public void Sliders_Load_Unload(string Load)
        {
            if (Load == "Load")
            {
                Slider1.Visibility = Visibility.Visible;
                Slider2.Visibility = Visibility.Visible;
                Slider3.Visibility = Visibility.Visible;
                Slider_Checker.Visibility = Visibility.Visible;
                Slider_Hidden_Image.Visibility = Visibility.Visible;
            }
            else
            {
                Slider1.Visibility = Visibility.Collapsed;
                Slider2.Visibility = Visibility.Collapsed;
                Slider3.Visibility = Visibility.Collapsed;
                Slider_Checker.Visibility = Visibility.Collapsed;
                Slider_Hidden_Image.Visibility = Visibility.Collapsed;
            }
        }
        public void ComboBoxes_Load_Unload(string Load)
        {
            if (Load == "Load")
            {
                ComboRed.Visibility = Visibility.Visible;
                ComboGreen.Visibility = Visibility.Visible;
                ComboBlue.Visibility = Visibility.Visible;
            }
            else
            {
                ComboRed.Visibility = Visibility.Collapsed;
                ComboGreen.Visibility = Visibility.Collapsed;
                ComboBlue.Visibility = Visibility.Collapsed;
            }
        }
        public void MouseMaze_Load_Unload(string Load)
        {
            if (Load == "Load")
            {
                Border_Button_1.Visibility = Visibility.Visible;
                Border_Button_2.Visibility = Visibility.Visible;
                Border_Button_3.Visibility = Visibility.Visible;
                Border_Button_4.Visibility = Visibility.Visible;
                Border_Button_5.Visibility = Visibility.Visible;
                Border_Button_6.Visibility = Visibility.Visible;
                Border_Button_7.Visibility = Visibility.Visible;
                Border_Click_Button.Visibility = Visibility.Visible;
            }
            else
            {
                Border_Button_1.Visibility = Visibility.Collapsed;
                Border_Button_2.Visibility = Visibility.Collapsed;
                Border_Button_3.Visibility = Visibility.Collapsed;
                Border_Button_4.Visibility = Visibility.Collapsed;
                Border_Button_5.Visibility = Visibility.Collapsed;
                Border_Button_6.Visibility = Visibility.Collapsed;
                Border_Button_7.Visibility = Visibility.Collapsed;
                Border_Click_Button.Visibility = Visibility.Collapsed;
            }
        }
        public void ColourClicker_load_Unload(string Load)
        {
            if (Load == "Load")
            {
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
            }
            else
            {
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
            }
        }
        public void TypeRacer_Load_Unload(string Load)
        {
            if (Load == "Load")
            {
                Type_Race_Start_Button.Visibility = Visibility.Visible;
                Type_Race_Master_Box.Visibility = Visibility.Visible;
                Type_Race_Enter_Box.Visibility = Visibility.Visible;
            }
            else
            {
                Type_Race_Start_Button.Visibility = Visibility.Collapsed;
                Type_Race_Master_Box.Visibility = Visibility.Collapsed;
                Type_Race_Enter_Box.Visibility = Visibility.Collapsed;
            }
        }
        // End Of Loading Code
        public partial class NativeMethods //some code i stole to get mouse position in relation to the GameWindow.
        {
            /// Return Type: BOOL->int  
            ///X: int  
            ///Y: int  
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }
        private double GetWindowLeft(Window window) //Gets coordinates of mouses x pos in relation to game window, also stolen
        {
            if (window.WindowState == WindowState.Maximized) // accounts for the window being maximised
            {
                var leftField = typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)leftField.GetValue(window);
            }
            else
                return window.Left;
        }
        private double GetWindowTop(Window window)//Gets coordinates of mouses y pos in relation to game window, also stolen
        {
            if (window.WindowState == WindowState.Maximized) // also accounts for Window being maximised
            {
                var TopField = typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)TopField.GetValue(window);
            }
            else
                return window.Top;
        }
        private void Colour_Guess_Start_1(int delay)
        {
            Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(delay).ContinueWith(a => this.Dispatcher.Invoke(() => {
                Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_6.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(delay).ContinueWith(b => this.Dispatcher.Invoke(() => {
                    Colour_Click_6.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_8.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(delay).ContinueWith(c => this.Dispatcher.Invoke(() => {
                        Colour_Click_8.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(delay).ContinueWith(d => this.Dispatcher.Invoke(() => { Colour_Guess_Start_2(delay); }));
                    }));
                }));
            }));
        }//First Part Of ColourGuess Demonstrating sequence
        private void Colour_Guess_Start_2(int delay)
        {
            Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
            Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(delay).ContinueWith(f => this.Dispatcher.Invoke(() => {
                Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_4.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(delay).ContinueWith(g => this.Dispatcher.Invoke(() => {
                    Colour_Click_4.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_2.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(delay).ContinueWith(h => this.Dispatcher.Invoke(() => {
                        Colour_Click_2.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_9.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(delay).ContinueWith(i => this.Dispatcher.Invoke(() => { Colour_Guess_Start_3(delay); }));
                    }));
                }));
            }));
        }//Second Part Of ColourGuess Demonstrating sequence
        private void Colour_Guess_Start_3(int delay)
        {
            Colour_Click_9.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
            Colour_Click_7.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
            Task.Delay(delay).ContinueWith(j => this.Dispatcher.Invoke(() => {
                Colour_Click_7.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Task.Delay(delay).ContinueWith(k => this.Dispatcher.Invoke(() => {
                    Colour_Click_3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                    Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                    Task.Delay(delay).ContinueWith(l => this.Dispatcher.Invoke(() => {
                        Colour_Click_1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                        Task.Delay(delay).ContinueWith(m => this.Dispatcher.Invoke(() => {
                            Colour_Click_5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
                        }));
                    }));
                }));
            }));
        }//Third Part Of ColourGuess Demonstrating sequence, Needed to be split into parts as too many Task.Delay after each other lags computer

    }
}
