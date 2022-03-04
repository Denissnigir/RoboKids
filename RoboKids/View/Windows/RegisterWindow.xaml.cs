using RoboKids.Model;
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

namespace RoboKids.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        User user;
        public RegisterWindow()
        {
            InitializeComponent();
            user = new User();
            MainGrid.DataContext = user;
        }

        private void ToLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(user.FIO) && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
            {
                user.IdRole = 2;
                Context._con.User.Add(user);
                Context._con.SaveChanges();
                MessageBox.Show($"Аккаунт пользователя {user.FIO} успешно зарегистрирован!");
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Сначала заполните все поля!");
            }
        }
    }
}
