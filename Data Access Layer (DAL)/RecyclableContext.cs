using SDSolutionsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SDSolutionsApp.Data_Access_Layer__DAL_
{
    //We create the database context for the entity framework
    public class RecyclableContext : DbContext //derives from the DbContext class
    {

        public DbSet<RecyclableItem> RecyclableItems { get; set; }
        public DbSet<RecyclableType> RecyclableTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //for setting ALL decimals in this project to have default integer places of 20 and decimal places of 2
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(20, 2));

            modelBuilder.Entity<RecyclableType>().HasIndex(x => x.Type).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        
    }
}