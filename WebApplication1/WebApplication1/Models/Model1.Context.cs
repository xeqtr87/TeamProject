﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class testEntities : DbContext
    {
        public testEntities()
            : base("name=testEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Route> Route { get; set; }
    
        public virtual ObjectResult<Route> ListDestination()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Route>("ListDestination");
        }
    
        public virtual ObjectResult<Route> ListDestination(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Route>("ListDestination", mergeOption);
        }
    }
}
