using RoboKids.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboKids.Model
{
    public partial class Circle
    {
        public int? user_role { get { return LoginWindow.curUser.IdRole; } }
    }
}
