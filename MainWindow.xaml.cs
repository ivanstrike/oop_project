using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
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

namespace oop_project
{
    ///<summary>
    ///Логика взаимодействия для MainWindow.xaml
    ///</summary>
    public partial class MainWindow : Window
    {
        UsersRepository usersRepository = new UsersRepository();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password.ToString();
            if(usersRepository.LogIn(email, password))
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                ChooseRestaurantPanel.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Пользователя с такими данными не существует"); }
        }

        public void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility= Visibility.Collapsed;
            RegistrationPanel.Visibility = Visibility.Visible;
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string password = ConvertSecureStringToString(PasswordBox.SecurePassword);
            string adress = txtAddress.Text;
            if (usersRepository.SignUp(name, surname, email, password, adress))
            {
                MessageBox.Show("Успешная регистрация");
                RegistrationPanel.Visibility = Visibility.Collapsed;
                LoginPanel.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Пользователь с такими данными уже существует");}

        }
        private void BackToLogIn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPanel.Visibility= Visibility.Collapsed;
            LoginPanel.Visibility = Visibility.Visible;
        }
        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private void SelectRestaurant_Click(object sender, RoutedEventArgs e)
        {
            //реализовать выбор ресторана из combobox
            /*if(Select.SelectedItem == "Вкусно и точка")
            {
                ChooseRestaurantPanel.Visibility= Visibility.Collapsed;
                MenuPanel_1.Visibility= Visibility.Visible;
            }*/
        }
    }
}
