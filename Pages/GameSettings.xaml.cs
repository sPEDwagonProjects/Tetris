﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using WpfTetris.Interfaces;

namespace WpfTetris.Pages
{
    public partial class GameSettings : UserControl, ICloseControl
    {
        private string oldText = "3000";


        public GameSettings()
        {
            InitializeComponent();

            StartDownDelaySlider.Value = Settings.StartDownDelay;
            StartDownDelaySlider.Minimum = Settings.EndDownDelay;
            StartDownDelaySlider.Maximum = 500;

            EndDownDelaySlider.Value = Settings.EndDownDelay;
            EndDownDelaySlider.Maximum = 500;
            EndDownDelaySlider.Minimum = 100;
            DownDelayChangeSlider.Value = Settings.DelayChange;
            VolumeSlider.Value = Settings.AudioVolume;


            ScoreTextbox.Text = oldText;
        }

        public event CloseControl CloseEvent;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseEvent?.Invoke();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.AudioVolume = VolumeSlider.Value;
            Settings.StartDownDelay = StartDownDelaySlider.Value;
            Settings.EndDownDelay = EndDownDelaySlider.Value;
            Settings.NextLevelScore = uint.Parse(ScoreTextbox.Text);
            Settings.DelayChange = DownDelayChangeSlider.Value;
            Settings.ShadowShow = (bool) ShowShadowCheckbox.IsChecked;
            Settings.ShadowColor = (ColorList.SelectedItem as Rectangle)?.Fill;
            CloseEvent?.Invoke();
        }

        private void ScoreTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ScoreTextbox.Text.Length == 0)
            {
                ScoreTextbox.Text = "3000";
            }
            else
            {
                uint res = 0;

                if (uint.TryParse(ScoreTextbox.Text.Trim(), out res))

                    oldText = ScoreTextbox.Text;

                else
                    ScoreTextbox.Text = oldText;
            }
        }

        private void ShowShadowCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            ColorPanel.Visibility = Visibility.Visible;
        }


        private void ShowShadowCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            ColorPanel.Visibility = Visibility.Collapsed;
        }

        private void StartDownDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            EndDownDelaySlider.Maximum = e.NewValue;
        }
    }
}