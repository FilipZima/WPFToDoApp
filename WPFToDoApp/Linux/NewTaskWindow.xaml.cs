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

namespace WPFToDoApp.Linux
{
    public partial class NewTaskWindow : Window
    {
        private ContextMgr _ctxMgr;

        public NewTaskWindow(ContextMgr ctxMgr)
        {
            _ctxMgr = ctxMgr;
            InitializeComponent();
        }

        public void SubmitClick(object sender, RoutedEventArgs e)
        {
            string title = CreateTextBox.Text;
            bool isDone = CreateCheckBox.IsChecked ?? false;

            ToDoEntity todo = new ToDoEntity
            {
                title = title,
                IsDone = isDone
            };

            _ctxMgr.Add(todo);

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
