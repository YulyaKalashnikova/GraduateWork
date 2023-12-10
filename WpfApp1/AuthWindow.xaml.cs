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
using System.Windows.Threading;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LogIn()
        {
            if (txtLogin.Text == string.Empty
                || txtPassword.Password == string.Empty)
            {
                MessageBox.Show("Заполните пустые поля!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ищем пользователя в БД
            var user = Helper.context.Users
                .FirstOrDefault(x => x.Login == txtLogin.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователя нет в системе!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на время действия пароля и на сброс
            var today = DateTime.Today;
            var dateCreatedPassword = Convert.ToDateTime(user.dateCreatedPass);
            var passExpirationTime = dateCreatedPassword.AddMonths(3);
            if (user.isDropped == true || today > passExpirationTime)
            {
                if (MessageBox.Show($"Пароль был сброшен или время действия пароля истекло! " +
                    $"Хотите установить новый пароль?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    new PassWindow.NewPassWindow().Show();
                    Close();
                    return;
                }
                else return;
            }
            if (user.isBlocked == true)
            {
                MessageBox.Show("Ваш аккаунт заблокирован! Обратитесь к администартору.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (user.HashPass != HashPass.hashPassword(txtPassword.Password))
            {
                user.PasswordCountAttempt--;
                try
                {
                    Helper.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show($"Неверный пароль! У вас осталось {user.PasswordCountAttempt} попытки.",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                // Если количество попыток закончилось 
                if (user.PasswordCountAttempt == 0)
                {
                    // Статус блокровки = true
                    user.isBlocked = true;
                    try
                    {
                        Helper.context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Количество попыток закончилось! " +
                        "Обратитесь к администратору для сброса пароля.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // Отсчитываем количество оставшихся дней до истечения пароля
            var daysLeft5 = passExpirationTime.AddDays(-5);
            var daysLeft4 = passExpirationTime.AddDays(-4);
            var daysLeft3 = passExpirationTime.AddDays(-3);
            var daysLeft2 = passExpirationTime.AddDays(-2);
            var daysLeft1 = passExpirationTime.AddDays(-1);
            /*Если пароль совпадает и роль пользователя в системе 
             * равна "Администратор", то открыть окно администраторов*/
            if (HashPass.hashPassword(txtPassword.Password) == user.HashPass
                && user.FKRoleID == 1)
            {
                // Возвращаем количество попыток обратно
                user.PasswordCountAttempt = 5;
                try
                {
                    Helper.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Предупреждаем о том, что скоро время действия пароля истечёт
                if (today == daysLeft5 || today == daysLeft4
                    || today == daysLeft3 || today == daysLeft2
                    || today == daysLeft1 || today == passExpirationTime)
                {
                    MessageBox.Show($"Время действия пароля " +
                        $"истекает {passExpirationTime.ToString("dd MMMM yyyy г.")}",
                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                new AdminWindow.AdminWindow().Show();
                Close();
            }
            /*Если пароль совпадает и роль пользователя в системе 
             * равна "Сотрудник", то открыть окно сотрудника*/
            else if (HashPass.hashPassword(txtPassword.Password) == user.HashPass
                && user.FKRoleID == 2)
            {
                user.PasswordCountAttempt = 5;
                try
                {
                    Helper.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (today == daysLeft5 || today == daysLeft4
                    || today == daysLeft3 || today == daysLeft2
                    || today == daysLeft1 || today == passExpirationTime)
                {
                    MessageBox.Show($"Время действия пароля " +
                        $"истекает {passExpirationTime.ToString("dd MMMM yyyy г.")}",
                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                new UserWindow.MainWindow(user).Show();
                Close();
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn(); 
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            new PassWindow.ChangePassWindow().Show();
            Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState
                = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Полностью завершить работу программы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}