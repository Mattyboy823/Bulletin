using Bulletin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bulletin.ViewModels
{
    public class LoginOptionViewModel : ExtendedBindableObject
    {
        private Color backgroundColor;
        public Color BackgroundColor
        {
            get => backgroundColor;
            set => SetProperty(ref backgroundColor, value);
        }
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        private string icon;
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }
        private ICommand tapCommand;
        public ICommand TapCommand
        {
            get => tapCommand;
            set => SetProperty(ref tapCommand, value);
        }
        public LoginOptionViewModel(string text, Action tapAction, Color bgColor, string icon = "")
        {
            Text = text;
            TapCommand = new Command(tapAction);
            BackgroundColor=bgColor;
            Icon = icon;
        }

    }
}
