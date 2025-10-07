using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFToDoApp.Linux;

namespace WPFToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Content is not Grid grid)
            {
                Console.WriteLine("Content is not a Grid");
                return;
            }

            grid.MouseLeftButtonDown += (s, e) => { 
                if (e.ChangedButton == MouseButton.Left) DragMove();
            };

            TodoListBox.MouseDoubleClick += (s, e) => {

            };
        }
    }
}