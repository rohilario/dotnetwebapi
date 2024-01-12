using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetwebapi.Models
{
    public class User
    {
        //auto increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // UNIQUE PK
        [Key]
        public int UserId { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string UserCpf { get; set; }
        [Required]
        public required string passwd { get; set; }

        public User() { }

        public User(string name, string cpf, string passwd)
        {
            this.UserName = name ?? throw new ArgumentNullException(nameof(name));
            this.UserCpf = cpf;
            this.passwd = passwd;
        }
    }
}