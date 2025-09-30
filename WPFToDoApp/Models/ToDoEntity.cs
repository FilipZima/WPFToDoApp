using System.ComponentModel;

namespace WPFToDoApp.Models
{
    public class ToDoEntity : INotifyPropertyChanged
    {
        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
            }
        }

        public readonly string title;

        private bool _isDone;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ToDoEntity(string title, bool isDone = false)
        {
            _isDone = isDone;
            this.title = title;
        }

        public override string ToString() => title;
    }
}
