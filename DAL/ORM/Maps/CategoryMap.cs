using DAL.ORM.Entity;

namespace DAL.ORM.Maps
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.Descripton).IsOptional();

            HasMany(x => x.Products).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryID);
        }
    }
}
