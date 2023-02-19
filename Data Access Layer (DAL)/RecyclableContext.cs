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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}