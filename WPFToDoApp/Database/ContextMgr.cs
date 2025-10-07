using WPFToDoApp.Models;

namespace WPFToDoApp.Database
{
    public class ContextMgr
    {
        private readonly ToDoContext _context;

        public ContextMgr(ToDoContext context)
        {
            _context = context;
        }

        public void Add(ToDoEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(ToDoEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ToDoEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public ToDoEntity? GetByID(int id) => _context.ToDoSet.Find(id);

        public ToDoEntity[] GetAll() => _context.ToDoSet.ToArray();
    }
}
