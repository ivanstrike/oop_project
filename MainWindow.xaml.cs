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
        Restaurant McDonalds = new Restaurant("McDonalds", "Красная площадь", "Лучший ресторан быстрого питания");
        Restaurant BurgerKing = new Restaurant("BurgerKing", "Балтийский переулок, д.5", "Бургер Кинг – это место, где готовят мясо на огне");
        Restaurant KfC = new Restaurant("KFC", "ул. Театральная, д.8", "Kentucky Fried Chicken (KFC) — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курятины");
        List<Restaurant> restlist = new List<Restaurant>();
        MenuItem Burger = new MenuItem("Бургер", "Вкусный бургер с курицей", 156.6);
        MenuItem Cola = new MenuItem("Coco-cola", "Газированый напиток", 89.8);
        MenuItem FreePotate = new MenuItem("Картошка фри", "Хрустящий картофель фри", 125.2);
        RestMenu menu1 = new RestMenu();
        RestMenu menu2 = new RestMenu();
        RestMenu menu3 = new RestMenu();

        public MainWindow()
        {
            InitializeComponent();
            restlist.Add(McDonalds);
            restlist.Add(BurgerKing);
            restlist.Add(KfC);

            SelectBox.DisplayMemberPath = "Name";
            foreach (Restaurant rest in restlist)
            {
                SelectBox.Items.Add(rest);
            }

            menu1.Add(Burger);
            menu1.Add(Cola);
            foreach (MenuItem item in menu1.Items)
            {
                MenuListBox1.Items.Add(item);
            }

            menu2.Add(Burger);
            menu2.Add(FreePotate);
            menu2.Add(Cola);
            foreach (MenuItem item in menu2.Items)
            {
                MenuListBox2.Items.Add(item);
            }

            menu3.Add(FreePotate);
            menu3.Add(Cola);
            foreach (MenuItem item in menu3.Items)
            {
                MenuListBox3.Items.Add(item);
            }

        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password.ToString();
            if (usersRepository.LogIn(email, password))
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                ChooseRestaurantPanel.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Пользователя с такими данными не существует"); }
        }

        public void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Collapsed;
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
            else { MessageBox.Show("Пользователь с такими данными уже существует"); }

        }
        private void BackToLogIn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPanel.Visibility = Visibility.Collapsed;
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
            if (SelectBox.SelectedItem != null)
            {
                Restaurant selectedRestaurant = (Restaurant)SelectBox.SelectedItem;
                ChooseRestaurantPanel.Visibility = Visibility.Collapsed;
                if (selectedRestaurant.Name == "McDonalds") { MenuPanel_1.Visibility = Visibility.Visible; }
                else
                {
                    if (selectedRestaurant.Name == "BurgerKing") { MenuPanel_2.Visibility = Visibility.Visible; }
                    else MenuPanel_3.Visibility = Visibility.Visible;
                }
            }
        }

        private void BackToSelect1_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel_1.Visibility = Visibility.Collapsed;
            ChooseRestaurantPanel.Visibility=Visibility.Visible;
        }

        private void BackToSelect2_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel_2.Visibility = Visibility.Collapsed;
            ChooseRestaurantPanel.Visibility = Visibility.Visible;
        }
        private void BackToSelect3_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel_3.Visibility = Visibility.Collapsed;
            ChooseRestaurantPanel.Visibility = Visibility.Visible;
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button addToCartButton = sender as Button;
            if (addToCartButton != null)
            {
                addToCartButton.Background = Brushes.GreenYellow;
                addToCartButton.Content = "Добавлено в заказ";            }
        }
        

        private void GoToOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
