using panatura.Model.Entities;

namespace panatura.Model.Repositories
{
    public class ProductsRepository: BaseRepository<int, Product>, IProductsRepository
    {
        public ProductsRepository(PanaturaContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}