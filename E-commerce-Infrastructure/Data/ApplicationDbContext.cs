using E_commerce_core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Data
{
    public class ApplicationDbContext:IdentityDbContext<Users,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options)
        :base(options){
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           builder.Entity<CustomerStores>().HasKey(x => new
           {
               x.CustomerId, x.StoresId
           });
            builder.Entity<ItemsUnits>().HasKey(x => new { 
            x.UnitId,x.ItemId
            });
            builder.Entity<InvItemStores>().HasKey(x => new { 
            x.StoresId, x.ItemId
            });
            builder.Entity<ShoppingCartItems>().HasKey(x => new
            {
                x.CustomerId,x.ItemId,x.SoresId
            });
            builder.Entity<InvoiceDetails>().HasKey(x => new
            {
                x.InvoiceId,x.ItemId
            });
            builder.Entity<Governments>().HasMany(x => x.Zones).WithOne(x => x.Governments).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Governments>().HasMany(x => x.Users).WithOne(x => x.Governments).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Governments>().HasMany(x => x.Cities).WithOne(x => x.Governments).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Governments>().HasMany(x => x.Stores).WithOne(x => x.Governments).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Zones>().HasMany(x => x.Users).WithOne(x => x.Zones).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Zones>().HasMany(x=>x.Stores).WithOne(x=>x.Zones).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Zones>().HasOne(x => x.Cities).WithMany(x => x.Zones).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cities>().HasMany(x=>x.Users).WithOne(x=>x.Cities).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Cities>().HasMany(x => x.Stores).WithOne(x => x.Cities).OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Classifications>().HasOne(x=>x.Users).WithMany(x=>x.Classifications).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShoppingCartItems>().HasOne(x => x.Users).WithMany(x => x.ShoppingCartItems).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ShoppingCartItems>().HasOne(x => x.Items).WithMany(x => x.ShoppingCartItems).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ShoppingCartItems>().HasOne(x => x.Stores).WithMany(x => x.ShoppingCartItems).OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Invoice>().HasMany(x=>x.InvoiceDetails).WithOne(x=>x.Invoice).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invoice>().HasOne(x => x.Users).WithMany(x => x.Invoice).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InvoiceDetails>().HasOne(x=>x.Items).WithMany(x => x.InvoiceDetails).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubGroups>().HasMany(x=>x.SubGroupTwo).WithOne(x=>x.SubGroups).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SubGroups>().HasMany(x=>x.Items).WithOne(x=>x.SubGroups).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SubGroups>().HasOne(x=>x.MainGroup).WithMany(x=>x.SubGroups).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubGroupTwo>().HasMany(x=>x.Items).WithOne(x=>x.SubGroupTwo).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SubGroupTwo>().HasOne(x => x.MainGroup).WithMany(x => x.SubGroupTwo).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MainGroup>().HasMany(x => x.Items).WithOne(x => x.MainGroup).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CustomerStores>().HasOne(x=>x.Users).WithMany(x=>x.CustomerStores).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<CustomerStores>().HasOne(x => x.Stores).WithMany(x => x.CustomerStores).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InvItemStores>().HasOne(x=>x.Items).WithMany(x=>x.InvItemStores).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<InvItemStores>().HasOne(x => x.Stores).WithMany(x => x.InvItemStores).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ItemsUnits>().HasOne(x=>x.Units).WithMany(x=> x.ItemsUnits).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ItemsUnits>().HasOne(x => x.Items).WithMany(x => x.ItemsUnits).OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Users> users { get; set; }
        public DbSet<Governments> governments { get; set; }
        public DbSet<Items> items { get; set; }
        public DbSet<Cities> cities { get; set; }
        public DbSet<Zones> zones { get; set; }
        public DbSet<MainGroup> mainGroups { get; set; }
        public DbSet<SubGroups> subGroups { get; set; }
        public DbSet<SubGroupTwo> subGroupsTwo { get; set; }
        public DbSet<Stores> stores { get; set; }
        public DbSet<InvItemStores> invItemStores { get; set; } 
        public DbSet<Classifications> classifications { get; set; }
        public DbSet<Units> units { get; set; }
        public DbSet<ItemsUnits> itemsUnits { get; set; }
        public DbSet<ShoppingCartItems> shoppingCartItems { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceDetails> invoicesDetails { get; set; } 
        public DbSet<CustomerStores> customerStores { get; set; }

    }
}
