using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class User_Password
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid USER_ID_FK { get; set; }

        [Required]
        public string PASSWORD_HASH { get; set; }

        public bool IS_ACTIVE { get; set; }

        [Required]
        public string CREATED_BY { get; set; }

        [Required]
        public DateTime CREATED_DATE { get; set; }

        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_DATE { get; set; }

        public User User { get; set; }
    }
}