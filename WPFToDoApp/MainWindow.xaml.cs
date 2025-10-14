using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using WPFToDoApp.Database;
using WPFToDoApp.Linux;
using WPFToDoApp.Models;

namespace WPFToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ToDoContext ctx = new ToDoContext();
            ContextMgr ctxMgr = new ContextMgr(ctx);

            InitializeComponent();

            TodoListBox.ItemsSource = ctxMgr.GetAll();

            if (Content is not Grid grid) return;

            AddButton.Click += (s, e) => {
                NewTaskWindow ntWindow = new NewTaskWindow(ctxMgr);
                ntWindow.Closing += (s, e) =>
                {
                    RefreshListBox(ctxMgr);
                };
                ntWindow.ShowDialog();
            };

            RemoveButton.Click += (s, e) =>
            {
                if (TodoListBox.SelectedItem is ToDoEntity toDoEntity)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you really want to remove '{toDoEntity.Title}'", "Entity deletion", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        ctxMgr.Remove(toDoEntity);
                        RefreshListBox(ctxMgr);
                    }
                }
            };
        }

        private void RefreshListBox(ContextMgr ctxMgr)
        {
            TodoListBox.ItemsSource = null;
            TodoListBox.ItemsSource = ctxMgr.GetAll();
        }

        private void CheckboxChecked(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                ctxMgr.GetByID((int)cb.DataContext);
            }
        }
    }
}