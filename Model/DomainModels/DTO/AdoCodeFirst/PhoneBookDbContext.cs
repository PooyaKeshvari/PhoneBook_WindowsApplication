using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.DomainModels.DTO.AdoCodeFirst
{
    public partial class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext()
            : base("name=Model1")
        {
        }

        public DbSet<DTO.ContactListAggregates.ContactList> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
