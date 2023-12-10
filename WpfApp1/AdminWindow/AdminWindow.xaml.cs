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
using System.Windows.Shapes;

namespace WpfApp1.AdminWindow
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Load();
            LoadData();
        }

        private void Load()
        {
            tableUsers.ItemsSource = Helper.context.Users.OrderBy(x => x.LastName).ToList();
        }

        public void LoadData()
        {
            // Поиск
            var usersList = Helper.context.Users.ToList();
            if (TBSearch.Text != "Введите здесь текст для поиска" && TBSearch.Text != string.Empty)
            {
                usersList = usersList.Where(x => x.LastName.ToLower().Contains(TBSearch.Text.ToLower().Trim())
                || x.FirstName.ToLower().Contains(TBSearch.Text.ToLower().Trim())
                || x.MiddleName.ToLower().Contains(TBSearch.Text.ToLower().Trim())
                || x.Login.ToLower().Contains(TBSearch.Text.ToLower().Trim())
                || x.Role.TitleRole.ToLower().Contains(TBSearch.Text.ToLower().Trim())).OrderBy(x => x.LastName).ToList();
            }
            tableUsers.ItemsSource = usersList;
        }

        // Событие, которое срабатывает при изменении поля поиска
        public void TBSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text != "Введите здесь текст для поиска" && TBSearch.Text != string.Empty)
            {
                LoadData();
            }
            if (TBSearch.Text == string.Empty)
            {
                tableUsers.ItemsSource = Helper.context.Users.ToList();
            }
        }

        // Если пользователь нажал на поле поиска, то убрать "Введите здесь текст для поиска"
        private void TBSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text == "Введите здесь текст для поиска")
            {
                TBSearch.Text = "";
            }
        }

        // Если пользователь нажал на что-то другое, то показать "Введите здесь текст для поиска"
        private void TBSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text == "")
            {
                TBSearch.Text = "Введите здесь текст для поиска";
            }
        }

        // Сброс пароля
        private void ResetPass()
        {
            if (tableUsers.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные из таблицы!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (tableUsers.SelectedItem is Users users)
            {
                if (MessageBox.Show($"Вы точно хотите сбросить пароль пользователя?", "Внимание",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    users.HashPass = null;
                    users.isDropped = true;
                    users.isBlocked = false;
                    users.PasswordCountAttempt = 5;
                    users.dateCreatedPass = null;
                    try
                    {
                        Helper.context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Пароль успешно сброшен!");
                }
            }
        }

        private void ResetPass_Click(object sender, RoutedEventArgs e)
        {
            ResetPass();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddAndEditUsersWindow().Show();
            Load();
            Close();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (tableUsers.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные из таблицы!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (tableUsers.SelectedItem is Users users)
            {
                new AddAndEditUsersWindow(users).Show();
                Load();
                Close();
            }
        }

        private void RemoveUser()
        {
            if (tableUsers.SelectedItem == null)
            {
                MessageBox.Show("Выберите данные из таблицы!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (tableUsers.SelectedItem is Users users)
            {
                if (MessageBox.Show($"Вы точно хотите удалить данные?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Helper.context.Users.Remove(users);
                    try
                    {
                        Helper.context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Load();
                }
            }
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            RemoveUser();
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new AuthWindow().Show();
            Close();
        }
    }
}