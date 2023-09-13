using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using simple_stock_management_system.Models;
using simple_stock_management_system.Repositories;

namespace simple_stock_management_system.ViewModels {
    public class LoginViewModel : ViewModelBase {
        
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private readonly IUserRepository _userRepository;
        
        public int ErrorMessageOpacity { get; set; }
        private bool _validData;
        
        //Properties
        public string Username {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }

        public SecureString Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Password));
            } 
        }

        public string ErrorMessage {
            get => _errorMessage;
            set {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible {
            get => _isViewVisible;
            set {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            } 
        }
        
        public bool ValidData
        {
            get => _validData;
            set
            {
                _validData = value;
                OnPropertyChanged(nameof(ValidData));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        
        //Constructor
        public LoginViewModel() {
            _userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj) {
            bool valid = !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                         Password != null && Password.Length >= 3;

            ValidData = valid;
    
            return valid;
        }


        private void ExecuteLoginCommand(object obj) {
            var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));

            if (isValidUser) {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else {
                ErrorMessage = "* Invalid username or password";
                ShowErrorMessageWithFadeIn();
            }
        }
        
        //Error message fade in animation
        private void ShowErrorMessageWithFadeIn()
        {
            ErrorMessageOpacity = 0;

            if (Application.Current.MainWindow != null) {
                if (Application.Current.MainWindow.FindName("ErrorMessageBorder") is Border border)
                {
                    var fadeInAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.1)
                    };

                    border.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
                }
            }
        }
    }
}
