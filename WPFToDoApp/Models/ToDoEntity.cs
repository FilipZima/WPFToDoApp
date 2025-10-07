using System.ComponentModel;

namespace WPFToDoApp.Models
{
    public class ToDoEntity : INotifyPropertyChanged
    {
        public int id;
        public string title;

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isDone;

        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(value)));
            }
        }

        public override string ToString() => title;
    }
}
