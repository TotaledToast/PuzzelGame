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
            GameStart(); // loads and unloads assets as needed.

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && PressSpace.IsVisible == true) // checks if the space key is pressed and if the press space button is visible
            {
                SpacePressed(); // loads assets for new stage
                GameWindow.Title = "RGB"; //if so move onto the next stage and set new gamewindow title
            }
            else if (PressSpace.IsVisible == true)
            {
                if (CurrentSpaceCycle < SpaceText.Count) //checks if all text options have been cycled
                {
                    PressSpace.Text = SpaceText[CurrentSpaceCycle]; // cycles through options defined in SpaceText if the key pressed isnt space.
                    CurrentSpaceCycle++;
                }
                else
                {
                    PressSpace.Text = PressSpace.Text + "."; // if SpaceText has run out of options it will add another . each key press
                }
            }

        }

        private void Slider_Checker_Click(object sender, RoutedEventArgs e)
        {
            if (Slider1.Value == 6 && Slider2.Value == 7 && Slider3.Value == 2) // checks if the correct slider values have been selected
            {
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Found.jpg"); // changes the image source
                Slider_Checker.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF50E617");
                Slider_Checker.Tag = "Clicked";                                                 //changes the button to green and sets this puzzle as completed.
            }
            else if(Slider_Checker.Tag.ToString() == "NotClicked") //checks if the combination given is wrong AND that it hasnt aready been answered correctly.
            {
                Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Wrong Answer.jpg"); //changed the image source to a red picture
                Task.Delay(450).ContinueWith(t => this.Dispatcher.Invoke(() => { Slider_Hidden_Image.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"../../Images/Gray Hidden.jpg"); })); // waits for 0.45 seconds before changing the image source back to the plain gray.
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
                ComboBlue.IsEnabled = false;            //checks if the correct options are picked and it they are then diabled the puzzle and give the answer.
            }
        }

        private void Border_Button_Click(object sender, RoutedEventArgs e)
        {
            NativeMethods.SetCursorPos(Convert.ToInt32(GetWindowLeft(GameWindow)) + 195, Convert.ToInt32(GetWindowTop(GameWindow)) + 70);
            //when the mouse hovers over a border button in the MouseMaze it will move it back to outside the maze.
        }

        private void Border_Click_Button_Click(object sender, RoutedEventArgs e)
        {
            Border_Button_1.Content = "2194";
            //gives the player the answer if the click the middle button in the MouseMaze
        }

        private void Colour_Guess_Start_Click(object sender, RoutedEventArgs e)
        {
            Colour_Guess_Start_1(500);
            //Starts the 'animation' of squares turning green and then back in the colour guesser
        }

        private void Colour_Button_Click(object sender, RoutedEventArgs e)
        {
            List<char> PressOrder = new List<char> //sets the order of buttons to be pressed
            {
                '3','6','8','1','5','4','2','9','7','3','1','5'
            };
            if (((Button)sender).Tag.ToString() == PressOrder[Convert.ToInt32(Colour_Guess_Start.Tag.ToString())].ToString())
                //checks if the button that was pressed was the next one in the order, decided by the Tag on ColourGuess Start and Button Tag
            {
                Colour_Guess_Start.Tag = ((Convert.ToInt32(Colour_Guess_Start.Tag.ToString())) + 1).ToString(); //increments the ColourGuess Tag to the next option in the list
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

                } //checks if the end of the list has been reached and if so disable the puzzle and give the answers
            }
            else
            {
                Colour_Guess_Start.Tag = "0"; // if the button press is incorrect then reset the progress.
                Colour_Guess_Start.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE03217"); // turns the button red
                Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => { Colour_Guess_Start.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FDDDDDDD"); }));
                //turns the button back to grey in .5 seconds.
            }

        }

        private void CPS_Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "0") //checks if this is the first click in a second
            {
                ((Button)sender).Tag = "1"; //sets click amount to 1
                Task.Delay(1000).ContinueWith(a => this.Dispatcher.Invoke(() => { CPS_Button.IsEnabled = false; //stars a timer to happen in the next second
                if (Convert.ToInt32(((Button)sender).Tag.ToString()) >= 11) //once a second has passes it checks if the clicks have reached a certain amount
                {
                    CPS_Button.Content = "672"; // if it has reached the amount it will keep the puzzle disabled and give the answer.
                }
                else
                {
                    CPS_Button.Content = "Try Again";
                        ((Button)sender).Tag = "0"; //resets the click count to 0
                    Task.Delay(500).ContinueWith(b => this.Dispatcher.Invoke(() => {
                        CPS_Button.IsEnabled = true;
                        CPS_Button.Content = "Click Me Fast!"; //re-enables the button in .5 seconds after it stops.
                    }));
                }
                }));
            }
            else
            {
                ((Button)sender).Tag = (Convert.ToInt32(((Button)sender).Tag.ToString()) + 1).ToString(); //if there has been at least 1 click and the button isnt disabled clicking will increment clicks by 1
            }
        }

        private void Type_Race_Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Type_Race_Enter_Box.IsEnabled = true;
            Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFE03217");//turns the box red
            Type_Race_Enter_Box.MaxLength = 1;//sets the max number of characters in the enter box as 1, because setting it to 0 removes the character limit.
            Task.Delay(1000).ContinueWith(a => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFDB230"); })); // turns the box orange after 1 second
            Task.Delay(2000).ContinueWith(a => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFF4FD30"); })); // after another second the box turns yellow
            Task.Delay(3000).ContinueWith(a => this.Dispatcher.Invoke(() => { Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2EE810"); // finally after 3 seconds the box turns green
                Type_Race_Enter_Box.MaxLength = 24; // increases the max character length to the length of the desired text input to allow the user to type it in.

            }));
            Task.Delay(8000).ContinueWith(a => this.Dispatcher.Invoke(() => { Type_Race_Enter_Box.IsEnabled = false; // after 8 seconds of the box being enabled it will be disabled again
                Type_Race_Start_Button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FDDDDDDD"); //turns button grey
                if (Type_Race_Enter_Box.Text == Type_Race_Master_Box.Text) // it will then check it the text is the same as requested
                {
                    Type_Race_Start_Button.Content = "4380";
                    Type_Race_Start_Button.IsEnabled = false; // if yes the puzzle is disabled and answer is given
                }
                else
                {
                    Type_Race_Enter_Box.Text = "Try Again";
                    Task.Delay(1500).ContinueWith(b => this.Dispatcher.Invoke(() => { Type_Race_Enter_Box.Text = ""; })); //if not the user is told to try again and the text is reset in 1.5 seconds
                }
            }));

        }
    }
}
