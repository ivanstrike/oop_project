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
        private int TypePanel;
        Restaurant McDonalds = new Restaurant("McDonalds", "Красная площадь", "Лучший ресторан быстрого питания");
        Restaurant BurgerKing = new Restaurant("BurgerKing", "Балтийский переулок, д.5", "Бургер Кинг – это место, где готовят мясо на огне");
        Restaurant KfC = new Restaurant("KFC", "ул. Театральная, д.8", "Kentucky Fried Chicken (KFC) — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курятины");
        List<Restaurant> restlist = new List<Restaurant>();
        MenuItem Burger = new MenuItem("Бургер", "Вкусный бургер с курицей", 156.6);
        MenuItem Cola = new MenuItem("Coco-cola", "Газировнаный напиток", 89.8);
        MenuItem FreePotate = new MenuItem("Картошка фри", "Хрустящий картофель фри", 125.2);
        RestMenu menu1 = new RestMenu();
        RestMenu menu2 = new RestMenu();
        RestMenu menu3 = new RestMenu();
        Order order = new Order();
        
        
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
            TotalAmountBlock.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
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
                MenuPanel.Visibility = Visibility.Visible;
                if (selectedRestaurant.Name == "McDonalds") {TypePanel = 0; McDonaldsMenu.Visibility = Visibility.Visible; BKMenu.Visibility = Visibility.Collapsed; KFCMenu.Visibility = Visibility.Collapsed; }
                else
                {
                    if (selectedRestaurant.Name == "BurgerKing") { TypePanel = 1; BKMenu.Visibility = Visibility.Visible; McDonaldsMenu.Visibility = Visibility.Collapsed; KFCMenu.Visibility = Visibility.Collapsed; }
                    else { TypePanel = 2; KFCMenu.Visibility = Visibility.Visible; BKMenu.Visibility = Visibility.Collapsed; McDonaldsMenu.Visibility = Visibility.Collapsed; }
                    }
            }
        }

        private void BackToSelect_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.Visibility = Visibility.Collapsed;
            ChooseRestaurantPanel.Visibility=Visibility.Visible;
        }

        
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button addToCartButton = sender as Button;
            if (addToCartButton != null)
            {
                if (sender is Button button && button.CommandParameter is MenuItem selectedItem)
                {
                    if (!IsInOrder(selectedItem))
                    {
                        CartItem cartItem = new CartItem(selectedItem.Name, selectedItem.Description, selectedItem.Price, 1);
                        order.Items.Add(cartItem);
                        OrderScroll.Items.Add(cartItem);
                        TotalAmountInMenu.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
                    }
                    else
                    {
                        foreach (CartItem item in order.Items)
                        {
                            if (selectedItem.Name == item.Name) item.Quantity++;
                            TotalAmountInMenu.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
                        }
                    }
                    TotalAmountBlock.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
                }
                
            }
        }

        private bool IsInOrder(MenuItem cartitem)
        {
            foreach (CartItem item in order.Items)
            {
                if (cartitem.Name == item.Name) return true;
            }
            return false;
        }
        

        private void GoToOrder_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.Visibility=Visibility.Collapsed;
            Order_Panel.Visibility = Visibility.Visible;
        }
        
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button decreaseButton && decreaseButton.Tag is CartItem orderItem)
            {
                if (orderItem.Quantity > 0)
                {
                    orderItem.Quantity--;
                }
                else
                {
                    OrderScroll.Items.Remove(orderItem);
                    order.Items.Remove(orderItem);
                }
                TotalAmountBlock.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
            }
        }
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button increaseButton && increaseButton.Tag is CartItem orderItem)
            {
                orderItem.Quantity++;
                TotalAmountBlock.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
            }
            
        }
        
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button increaseButton && increaseButton.Tag is CartItem orderItem)
            {
                OrderScroll.Items.Remove(orderItem);
                order.Items.Remove(orderItem);
                TotalAmountBlock.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
            }
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            TotalAmountInMenu.Text = $"Total amount: ${order.TotalAmountCount().ToString()}";
            Order_Panel.Visibility = Visibility.Collapsed;
            MenuPanel.Visibility = Visibility.Visible;
            if (TypePanel == 0)
            {
                McDonaldsMenu.Visibility = Visibility.Visible;
            }
            else if (TypePanel == 1)
            {
                BKMenu.Visibility = Visibility.Visible;
            }
            else if (TypePanel == 2)
            {
                KFCMenu.Visibility = Visibility.Visible;
            }
             
        }

        private void GoToPayment_Click(object sender, RoutedEventArgs e)
        {
            if (order.TotalAmountCount() > 0) 
            {
                Order_Panel.Visibility = Visibility.Collapsed;
                Payment_Panel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Выберите что-нибудь");
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            string cardnumber = CardNumberBox.Text;
            string expiration_date = ExpirationDateBox.Text;
            string cvv = CVVBox.Text;
            CreditCard card = new CreditCard(cardnumber, expiration_date, cvv);
            order.PaymentProcess(card);
            if (order.IsPaid)
            {
                MessageBox.Show("Оплата прошла успешно");
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
            }
        }
    }
}
