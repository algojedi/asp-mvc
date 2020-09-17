using Classrooms.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchoolContext _context;

    public UnitOfWork(SchoolContext context)
    {
        _context = context;
        Courses = new CourseRepository(_context);
    }

    public ICourseRepository Courses { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}