using System.Collections.Frozen;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using WPFToDoApp.Database;
using WPFToDoApp.Linux;
using WPFToDoApp.Models;
using WPFToDoApp.Windows;

namespace WPFToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoContext ctx;
        private ContextMgr ctxMgr;

        private ObservableCollection<ToDoEntity> todoList;

        public MainWindow()
        {
            ctx = new ToDoContext();
            ctxMgr = new ContextMgr(ctx);

            todoList = new ObservableCollection<ToDoEntity>(ctxMgr.GetAll());

            InitializeComponent();

            TodoListBox.ItemsSource = todoList;

            if (Content is not Grid grid) return;

            AddButton.Click += (s, e) => AddTodo();

            RemoveButton.Click += (s, e) => RemoveTodo();

            EditButton.Click += (s, e) => EditTodo();
        }

        private void RemoveTodo()
        {
            if (TodoListBox.SelectedItem is ToDoEntity toDoEntity)
            {
                MessageBoxResult result = MessageBox.Show($"Do you really want to remove '{toDoEntity.Title}'", "Entity deletion", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    todoList.Remove(toDoEntity);
                    ctxMgr.Remove(toDoEntity);
                    RefreshListBox(ctxMgr);
                }
            }
        }

        private void AddTodo()
        {
            NewTaskWindow ntWindow = new NewTaskWindow(ctxMgr);
            ntWindow.Closed += (s, e) =>
            {
                todoList.Clear();
                ctxMgr.GetAll().ForEach(x => todoList.Add(x));
                RefreshListBox(ctxMgr);
            };
            ntWindow.ShowDialog();
        }

        private void EditTodo()
        {
            if (TodoListBox.SelectedItem is ToDoEntity entity)
            {
                EditTitleWindow etWindow = new EditTitleWindow(ctxMgr, entity);
                etWindow.Closed += (s, e) =>
                {
                    todoList.Clear();
                    ctxMgr.GetAll().ForEach(x => todoList.Add(x));
                    RefreshListBox(ctxMgr);
                };
                etWindow.ShowDialog();
            }
        }

        private void RefreshListBox(ContextMgr ctxMgr)
        {
            TodoListBox.ItemsSource = null;
            TodoListBox.ItemsSource = todoList;
        }

        private void CheckboxChecked(object sender, EventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is ToDoEntity todo)
            {
                ctxMgr.GetByID((int)cb.DataContext);
                todo.IsDone = cb.IsChecked ?? false;
                ctxMgr.Update(todo);
            }
        }
    }
}