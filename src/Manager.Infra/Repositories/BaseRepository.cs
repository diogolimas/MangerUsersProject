namespace Manager.Infra.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where  T: BaseRepository
    {

        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);

            await _context.SaveChangesAsync();

            return obj;
        }
    }

    
}