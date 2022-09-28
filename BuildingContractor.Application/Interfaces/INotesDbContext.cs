using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Customer> customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
