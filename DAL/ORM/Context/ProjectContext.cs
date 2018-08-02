using DAL.ORM.Entity;
using DAL.ORM.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=ISA\SQLEXPRESS;Database=DENEME_MVC_CALISMA;Integrated Security=true";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder); 
        }

        public override int SaveChanges()
        {
            //SaveChanges override edilirse artık yeni eklenen kayıtlarda eklenme tarihi veya status yazılmak zorunda değildir. Burada yapılacaktır.

            //En son eklenen veya değişiklik yapılan tüm entityler yakalanır    
            var addedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var item in addedEntries)
            {
                BaseEntity entity = item.Entity as BaseEntity;

                if (item!=null)
                {
                    //Eğer yakalanan nesneler yeni eklenmişse
                    if (item.State==EntityState.Added)
                    {
                        entity.AddedDate = DateTime.Now;
                        entity.Status = Entity.Enum.Status.Active;
                    }
                    //else if (item.State==EntityState.Modified)
                    //{
                    //    entity.Status = Entity.Enum.Status.Updated;
                    //}
                }
            }

            return base.SaveChanges();  
        }
    }
}
