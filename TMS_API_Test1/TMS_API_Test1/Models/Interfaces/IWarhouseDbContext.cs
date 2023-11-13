using Microsoft.EntityFrameworkCore;
using TMS_API_Test1.Models.Product;

namespace TMS_API_Test1.Models.Interfaces
{
    public interface IWarhouseDbContext
    {
        DbSet<ProductModels> Notes { get; set; }
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
