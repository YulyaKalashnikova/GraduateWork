using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.AdminWindow
{
    /// <summary>
    /// Interaction logic for AddAndEditUsersWindow.xaml
    /// </summary>
    public partial class AddAndEditUsersWindow : Window
    {
        public AddAndEditUsersWindow()
        {
            InitializeComponent();
            Load();
            DataContext = new Users();
        }

        public AddAndEditUsersWindow(Users users)
        {
            InitializeComponent();
            Load();
            DataContext = users;

            txtLogin.Text = users.Login;
            txtPassword.Password = users.HashPass;

            CmBRole.SelectedItem = users.FKRoleID;
        }

        private void Load()
        {
            CmBRole.ItemsSource = Helper.context.Role.OrderBy(x => x.TitleRole).ToList();
        }

        private void GeneratePass()
        {
            string chars = "!@#$%^&?()*_0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int defaultLengthPass = 12;
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < defaultLengthPass; i++)
            {
                int index = random.Next(chars.Length); // записываем в index псевдорандомный символ
                sb.Append(chars[index]); // при помощи Append добавляем строке подстроку в виде одного символа
            }
            string result = sb.ToString(); // записываем в переменную result всё, что у нас нагенерировалось
            txtPassword.Password = result;
            txtCheckPass.Text = result;
            MessageBox.Show("Пароль сгенерирован!");
        }

        private void GeneratePass_Click(object sender, RoutedEventArgs e)
        {
            GeneratePass();
        }

        private void CheckPassCB_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                txtCheckPass.Text = txtPassword.Password; //копируем в TextBox из PasswordBox      
                txtCheckPass.Visibility = Visibility.Visible; // TextBox - отобразить   
                txtPassword.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                txtPassword.Password = txtCheckPass.Text; // копируем в PasswordBox из TextBox       
                txtCheckPass.Visibility = Visibility.Hidden; // TextBox - скрыть
                txtPassword.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }

        private void SaveUser()
        {
            if (DataContext is Users users)
            {
                if (txtLastName.Text == string.Empty
                    || txtFirstName.Text == string.Empty
                    || txtLogin.Text == string.Empty
                    || txtPassword.Password == string.Empty
                    || txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Заполните пустые поля!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var role = CmBRole.SelectedItem as Role;
                if (role.Role_ID == 0)
                {
                    MessageBox.Show("Выберите данные из выпадающего списка!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Добавление пользователя
                if (users.Users_ID == 0)
                {
                    if (Helper.context.Users.Select(x => x.Login).Contains(txtLogin.Text))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (txtPassword.Password.Length < 6)
                    {
                        MessageBox.Show("Пароль слишком короткий!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (!Regex.IsMatch(txtEmail.Text.Replace(" ", ""), @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
                    {
                        MessageBox.Show("Почта не валидна!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    users.Login = txtLogin.Text;
                    users.PasswordCountAttempt = 5;
                    users.Email = txtEmail.Text;
                    users.dateCreatedPass = DateTime.Today;
                    users.isDropped = false;
                    users.isBlocked = false;
                    users.FKRoleID = role.Role_ID;
                    users.HashPass = HashPass.hashPassword(txtPassword.Password);
                    Helper.context.Users.Add(users);
                }
                // Изменение пользователя
                else
                {
                    // если при сохранении данных, логин пользователя, не совпадает с другими логинами в БД 
                    if (!Helper.context.Users.Select(x => x.Login).Contains(txtLogin.Text))
                    {
                        if (!Regex.IsMatch(txtEmail.Text.Replace(" ", ""), @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
                        {
                            MessageBox.Show("Почта не валидна!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        // Если администратор изменил пароль пользователя
                        if (HashPass.hashPassword(txtPassword.Password) != users.HashPass)
                        {
                            users.PasswordCountAttempt = 5;
                            users.isBlocked = false;
                            users.isDropped = false;
                        }
                        users.Login = txtLogin.Text;
                        users.HashPass = HashPass.hashPassword(txtPassword.Password);
                        users.FKRoleID = role.Role_ID;
                        users.Login = txtLogin.Text;
                        users.FKRoleID = role.Role_ID;
                    }
                    // если логин уже существует, то...
                    else
                    {
                        // если в TextBox'e логин равен логину, который записан у пользователя, которого изменяют, то данные можно сохранять
                        if (txtLogin.Text == users.Login)
                        {
                            users.Login = txtLogin.Text;
                            users.HashPass = HashPass.hashPassword(txtPassword.Password);
                            users.FKRoleID = role.Role_ID;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
            }
            try
            {
                Helper.context.SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            new AdminWindow().Show();
            Close();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            SaveUser();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new AdminWindow().Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Полностью завершить работу программы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState
                = WindowState.Minimized;
        }
    }
}