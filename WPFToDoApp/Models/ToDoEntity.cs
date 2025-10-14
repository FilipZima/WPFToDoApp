using System.ComponentModel;

namespace WPFToDoApp.Models
{
    public class ToDoEntity : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

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

        public override string ToString() => Title;
    }
}
