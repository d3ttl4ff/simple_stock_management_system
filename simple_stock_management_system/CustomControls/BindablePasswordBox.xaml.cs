using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace simple_stock_management_system.CustomControls {
    public partial class BindablePasswordBox : UserControl {

        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Pass", typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Pass {
            get { return (SecureString)GetValue(PasswordProperty); }
            set{ SetValue(PasswordProperty, value);}
        }
        
        public BindablePasswordBox() {
            InitializeComponent();
            TxtPass.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e) {
            Pass = TxtPass.SecurePassword;
        }
    }
}

