using DAL.ORM.Entity;


namespace DAL.ORM.Maps
{
    public class ProductMap:BaseMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Product");
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.UnitsInStock).IsOptional();
            Property(x => x.Quantity).IsOptional();

            HasRequired(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID).WillCascadeOnDelete(false);
        }
    }
}
