﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laminatsia
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LaminatsiaEntities : DbContext
    {
        public LaminatsiaEntities()
            : base("name=LaminatsiaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ColourProfile> ColourProfile { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ColourGoods> ColourGoods { get; set; }
        public DbSet<Archive> Archive { get; set; }
    }
}
