using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Bulletin.PageModels.Base;
using Xamarin.Forms;

namespace Bulletin.ViewModels.Buttons
{
    public class ButtonModel : ExtendedBindableObject
    {
        string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }
        bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        ICommand command;
        public ICommand Command
        {
            get => command;
            set => SetProperty(ref command, value);
        }

        public ButtonModel(string title, ICommand command, bool isVIsible = true, bool isEnabled = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVIsible;
            IsEnabled = isEnabled; 
        }

        public ButtonModel(string text, Action action, bool isVisible = true, bool isEnabled = true)
        {
            Text = text;
            Command = new Command(action); 
            IsVisible = isVisible;
            IsEnabled = isEnabled;
        }
    }
}
