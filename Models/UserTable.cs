namespace TheSnehiNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTable")]
    public partial class UserTable
    {
        [Key]
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public string UserMail { get; set; }

        public string UserPassword { get; set; }
    }
}
