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

namespace FleetManagementSystem.Resources.PasswordBoxNew
{
    /// <summary>
    /// Logika interakcji dla klasy PasswordBoxNeew.xaml
    /// </summary>
    public partial class PasswordBoxNeew : UserControl
    {
        readonly System.Timers.Timer timer = new(300);
        public PasswordBoxNeew()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
        }

        public string PasswordText
        {
            get { return (string)GetValue(PasswordTextProperty); }
            set { SetValue(PasswordTextProperty, value); }
        }
        public static readonly DependencyProperty PasswordTextProperty =
            DependencyProperty.Register("PasswordText", typeof(string), typeof(PasswordBoxNeew), new PropertyMetadata(string.Empty));

        public string PasswordTagLabel
        {
            get { return (string)GetValue(PasswordTagLabelProperty); }
            set { SetValue(PasswordTagLabelProperty, value); }
        }
        public static readonly DependencyProperty PasswordTagLabelProperty =
            DependencyProperty.Register("PasswordTagLabel", typeof(string), typeof(PasswordBoxNeew), new PropertyMetadata(string.Empty));

        public bool ClearPass
        {
            get { return (bool)GetValue(ClearPassProperty); }
            set { SetValue(ClearPassProperty, value); }
        }
        public static readonly DependencyProperty ClearPassProperty =
            DependencyProperty.Register("ClearPass", typeof(bool), typeof(PasswordBoxNeew), new PropertyMetadata(false));

        /// <summary>
        /// Ukryj label Tag
        /// </summary>
        private void HideTag()
        {
            TagLabel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Pokaż label Tag i ukryj label maskowania
        /// </summary>
        private void ShowTag()
        {
            MaskingLabel.Visibility = Visibility.Collapsed;
            TagLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Ukryj label maskowania
        /// </summary>
        private void HideMaskingLabel()
        {
            MaskingLabel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Pokaż label maskowania i uktryj label Tag
        /// </summary>
        private void ShowMaskingLabel()
        {
            MaskingLabel.Visibility = Visibility.Visible;
            TagLabel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Pokaż tag jeżeli hasło ma pusty text lub pokaż maskę i wylicz maskowanie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (PasswordBox.Text == string.Empty || PasswordBox.Text == "")
            {
                ShowTag();
                return;
            }
            if (PasswordBox.Text.Length > 0)
            {
                ShowMaskingLabel();
                MaskingLabel.Text = string.Empty;
                for (int i = 0; i < PasswordBox.Text.Length - 1; i++)
                {
                    MaskingLabel.Text += "●";
                }
                MaskingLabel.Text += PasswordBox.Text.Substring(PasswordBox.Text.Length - 1);
                timer.Start();
            }
        }

        /// <summary>
        /// Pokaż Tag, jeżeli teext hasła jest pusty inaczej pokaż maskowanie hasła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text == string.Empty || PasswordBox.Text == "")
            {
                ShowTag();
            }
            else
            {
                ShowMaskingLabel();
            }
        }

        /// <summary>
        /// Ukryj Labele pomocnicze aby pokazać Text hasła
        /// </summary>
        private void ShowPassword()
        {
            HideMaskingLabel();
            HideTag();
        }

        /// <summary>
        /// Nadaj fokus dla textboxa zawierającego password i ukryj pomocnicze labele
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBoxFocus(object sender, MouseButtonEventArgs e)
        {
            PasswordBox.Focus();
            ShowPassword();
        }

        /// <summary>
        /// Ukryj pomocnicze labele by pokazać hasło
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPasswordClick(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        /// <summary>
        /// Przykryj hasło odpowiednim pomocniczym labelem, maską lub tagiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HidePasswordClick(object sender, MouseButtonEventArgs e)
        {
            if (PasswordBox.Text == string.Empty || PasswordBox.Text == "")
            {
                ShowTag();
            }
            else
            {
                ShowMaskingLabel();
            }
        }

        /// <summary>
        /// Gdy textbox z hasłem ma fokus, ukryj wszystkie pomocnicze labele
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBoxGotFocus(object sender, RoutedEventArgs e)
        {
            HideMaskingLabel();
            HideTag();
        }

        /// <summary>
        /// Wyczyść hasło i pokaż tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetPasswordChecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Text = string.Empty;
            ShowTag();
        }

        /// <summary>
        /// Po odliczeniu czasu ukryj ostatni znak hasła maską
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            this.Dispatcher.Invoke(() => MaskPassword());
        }

        /// <summary>
        /// Maskowanie hasła
        /// </summary>
        private void MaskPassword()
        {
            MaskingLabel.Text = string.Empty;
            for (int i = 0; i < PasswordBox.Text.Length; i++)
            {
                MaskingLabel.Text += "●";
            }
        }
    }
}
