using System.Threading;
using System.Threading.Tasks;

namespace KalaGhar.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //DbSet<TodoList> TodoLists { get; set; }

        //DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
