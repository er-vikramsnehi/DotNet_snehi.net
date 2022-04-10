using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheSnehiNetwork.Models
{
    public partial class CodeFirst : DbContext
    {
        public CodeFirst()
            : base("name=CodeFirst")
        {
        }

        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
