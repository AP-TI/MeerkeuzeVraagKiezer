using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MeerkeuzeVraagKiezer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    enum Keuze { A, B, C, D, E, F, G, H, I, J, K}
    public sealed partial class MainPage : Page
    {
        static Random random = new Random();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonGooi_Click(object sender, RoutedEventArgs e)
        {
            bool goOn;
            string letter = "";
            do
            {
                goOn = false;
                letter = ((Keuze)random.Next(0, int.Parse(textBoxAantalKeuzes.Text))).ToString();

                foreach (Control control in stackPanelCheckBoxes.Children)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        if(!(bool)checkBox.IsChecked && letter == (string)checkBox.Content)
                            goOn = true;
                    }
                }
            } while (goOn);
            textBlockResultaat.Text = letter;
        }

        private void TextBoxAantalKeuzes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(textBoxAantalKeuzes.Text, out int result))
            {
                Visibility visibility = Visibility.Visible;
                switch (result)
                {
                    case 1:
                        checkBoxA.Visibility = visibility;
                        break;
                    case 2:
                        checkBoxB.Visibility = visibility;
                        goto case 1;
                    case 3:
                        checkBoxC.Visibility = visibility;
                        goto case 2;
                    case 4:
                        checkBoxD.Visibility = visibility;
                        goto case 3;
                    case 5:
                        checkBoxE.Visibility = visibility;
                        goto case 4;
                    case 6:
                        checkBoxF.Visibility = visibility;
                        goto case 5;
                    case 7:
                        checkBoxG.Visibility = visibility;
                        goto case 6;
                    case 8:
                        checkBoxH.Visibility = visibility;
                        goto case 7;
                    case 9:
                        checkBoxI.Visibility = visibility;
                        goto case 8;
                    case 10:
                        checkBoxJ.Visibility = visibility;
                        goto case 9;
                    case 11:
                        checkBoxK.Visibility = visibility;
                        goto case 10;
                    default:
                        visibility = Visibility.Collapsed;
                        goto case 11;
                }
            }
            else
            {
                foreach(Control control in stackPanelCheckBoxes.Children)
                {
                    if (control is CheckBox)
                        control.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
