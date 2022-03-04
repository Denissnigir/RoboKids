using RoboKids.Model;
using RoboKids.View.Pages.CoursePage;
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
    /// Логика взаимодействия для MyCourses.xaml
    /// </summary>
    public partial class MyCourses : Page
    {
        List<UserCircle> userCircles = new List<UserCircle>();
        public MyCourses()
        {
            InitializeComponent();
            userCircles = Context._con.UserCircle.ToList()
                                                 .Where(p => p.IdIUser == LoginWindow.curUser.Id)
                                                 .ToList();
            CoursesList.ItemsSource = userCircles;
        }

        private void ToLessons(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as UserCircle;
            var circle = Context._con.Circle.ToList().Where(p => p.Id == context.IdCircle).FirstOrDefault();
            NavigationService.Navigate(new CourseEvent(circle));
        }

        private void DeleteCourse(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as UserCircle;
            if (MessageBox.Show(
                $"Вы действительно хотите покинуть кружок {context.Circle.NameCircle}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var userCircle = Context._con.UserCircle.ToList()
                                                        .Where(p => p.IdIUser == LoginWindow.curUser.Id && p.IdCircle == context.Circle.Id)
                                                        .FirstOrDefault();
                Context._con.UserCircle.Remove(userCircle);
                Context._con.SaveChanges();
                var userLessons = Context._con.UserLesson.ToList()
                                                         .Where(p => p.IdUser == LoginWindow.curUser.Id && p.Lesson.IdCircle == context.Id)
                                                         .ToList();
                if (userLessons != null)
                {
                    foreach (var lesson in userLessons)
                    {
                        Context._con.UserLesson.Remove(lesson);
                        Context._con.SaveChanges();
                    }
                }

                userCircles = Context._con.UserCircle.ToList()
                                                     .Where(p => p.IdIUser == LoginWindow.curUser.Id)
                                                     .ToList();
                CoursesList.ItemsSource = userCircles;

                MessageBox.Show("Вы успешно покинули кружок!");
            }
            
        }
    }
}
