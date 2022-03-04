using RoboKids.Model;
using RoboKids.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoboKids.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllCourses.xaml
    /// </summary>
    public partial class AllCourses : Page
    {
        List<Circle> circles = new List<Circle>();

        public AllCourses()
        {
            InitializeComponent();
            circles = Context._con.Circle.ToList();
            CoursesList.ItemsSource = circles;
            if (LoginWindow.curUser.IdRole == 1)
            {

            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as Circle;
            var checkCircle = Context._con.UserCircle.ToList()
                                                     .Where(p => p.IdCircle == context.Id && p.IdIUser == LoginWindow.curUser.Id)
                                                     .FirstOrDefault();
            if (checkCircle == null)
            {
                UserCircle userCircle = new UserCircle();
                userCircle.IdCircle = context.Id;
                userCircle.IdIUser = LoginWindow.curUser.Id;
                Context._con.UserCircle.Add(userCircle);
                Context._con.SaveChanges();
                MessageBox.Show("Вы успешно записались на кружок!");
            }
            else
            {
                MessageBox.Show("Вы уже записаны на этот кружок!");
            }
        }

        private void DeleteCourse(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as Circle;
            if (MessageBox.Show(
                $"Вы действительно хотите удалить кружок {context.NameCircle}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Context._con.Circle.Remove(context);
                Context._con.SaveChanges();
                circles = Context._con.Circle.ToList();
                CoursesList.ItemsSource = circles;
                MessageBox.Show("Кружок успешно удалён!");
            }

        }
    }
}
