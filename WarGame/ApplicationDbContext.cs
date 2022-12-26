using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using WarGame.Entities;
using WarGame.Utils;

namespace WarGame
{

    public class ApplicationDbContext : DbContext
    {
        protected ObjectContext ObjectContext { get; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public void Detach(object entity)
        {
           ObjectContext.Detach(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Queue<Card> cards = GameTools.CreateCards();

            modelBuilder.Entity<Card>().HasData(cards);

            modelBuilder.Entity<DeckCards>().HasKey(dc => new { dc.deckId, dc.cardId });

            modelBuilder.Entity<GamePlayers>().HasKey(gp => new { gp.gameId, gp.playerId });

            modelBuilder.Entity<Game>().Property(x => x.winnerId).IsRequired(false);

            modelBuilder.Entity<Event>().Property(e => e.action).HasConversion<string>();
            //Defaults
            //modelBuilder.Entity<Place>().Property(x => x.lati).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();





            /*  //Ignored Properties
              modelBuilder.Entity<PriceList>().Ignore(p => p.materials);
              modelBuilder.Entity<PriceListMaterialDiscount>().Ignore(p => p.material);
              modelBuilder.Entity<SalesOrder>().Ignore(p => p.network);

              //Defaults
              modelBuilder.Entity<Area>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Area>().Property(x => x.updatedAt).IsRequired(false);

              modelBuilder.Entity<Area>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Brand>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Brand>().Property(x => x.updatedAt).IsRequired(false);

              modelBuilder.Entity<Brand>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Category>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Category>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Category>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Contact>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Contact>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Contact>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Discount>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Discount>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Discount>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Employee>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Employee>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Employee>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Material>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Material>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Material>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<MaterialGroup>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<MaterialGroup>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<MaterialGroup>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Network>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Network>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Network>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<Place>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<Place>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<Place>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<PriceList>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<PriceList>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<PriceList>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<SalesDocument>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<SalesDocument>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<SalesDocument>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<SalesOrder>().Property(x => x.createdAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<SalesOrder>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<SalesOrder>().Property(x => x.deletedAt).IsRequired(false);
              modelBuilder.Entity<SalesOrder>().Property(x => x.employeeLatitude).IsRequired(false);
              modelBuilder.Entity<SalesOrder>().Property(x => x.employeeLongitude).IsRequired(false);



              modelBuilder.Entity<SubCategory1>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<SubCategory1>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<SubCategory1>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<SubCategory2>().Property(x => x.createdAt).IsRequired(false).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
              modelBuilder.Entity<SubCategory2>().Property(x => x.updatedAt).IsRequired(false);
              modelBuilder.Entity<SubCategory2>().Property(x => x.deletedAt).IsRequired(false);

              modelBuilder.Entity<PriceListMaterialDiscount>().Property(x => x.times).HasDefaultValue(1);


              //Composite primary key (2 keys)

              modelBuilder.Entity<DiscountTotals>().HasKey(dt => new { dt.id, dt.salesOrderID });

              modelBuilder.Entity<EmployeeMaterial>().HasKey(em => new { em.employeeId, em.materialId });
              modelBuilder.Entity<EmployeeArea>().HasKey(ea => new { ea.employeeID, ea.areaID });

              modelBuilder.Entity<NetworkPlace>().HasKey(np => new { np.networkID, np.placeID });
              modelBuilder.Entity<NetworkMaterial>().HasKey(nm => new { nm.networkID, nm.materialID });

              modelBuilder.Entity<PlaceEmployee>().HasKey(pe => new { pe.placeID, pe.employeeID });

              modelBuilder.Entity<SalesDocumentPlace>().HasKey(plp => new { plp.placeID, plp.salesDocumentID });
              modelBuilder.Entity<PriceListMaterial>().HasKey(plm => new { plm.materialID, plm.priceListID });

              modelBuilder.Entity<SalesOrderMaterial>().HasKey(som => new { som.salesOrderID, som.materialID });

              //Composite primary key (3 keys)

              modelBuilder.Entity<CalculatedDiscount>().HasKey(p => new { p.id, p.salesOrderID, p.materialID });
              modelBuilder.Entity<SalesOrderMaterial>()
                  .HasMany(p => p.calculatedDiscounts)
                  .WithOne(c => c.salesOrderMaterial)
                  .HasForeignKey(c => new { c.salesOrderID, c.materialID });

              modelBuilder.Entity<PriceListMaterialDiscount>().HasKey(p => new { p.materialID, p.priceListID, p.discountID });
              modelBuilder.Entity<PriceListMaterial>()
                  .HasMany(p => p.priceListMaterialDiscounts)
                  .WithOne(c => c.priceListMaterials)
                  .HasForeignKey(c => new { c.materialID, c.priceListID });

              */

        }

        //DB SETS
        public DbSet<Card> Card { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GamePlayers> GamePlayers { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Event> Event { get; set; }



    }
}
