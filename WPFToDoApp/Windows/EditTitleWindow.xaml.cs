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
using WPFToDoApp.Database;
using WPFToDoApp.Models;

namespace WPFToDoApp.Windows
{
    /// <summary>
    /// Interakční logika pro EditTitleWindow.xaml
    /// </summary>
    public partial class EditTitleWindow : Window
    {
        ContextMgr ctxMgr;
        ToDoEntity oldTodo;

        public EditTitleWindow(ContextMgr ctx, ToDoEntity oldTodo)
        {
            this.oldTodo = oldTodo;
            InitializeComponent();
            ctxMgr = ctx;
        }

        public void SubmitClick(object sender, RoutedEventArgs e)
        {
            string title = EditTextBox.Text;

            oldTodo.Title = title;

            ctxMgr.Update(oldTodo);

            DialogResult = true;
            Close();
        }

        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
