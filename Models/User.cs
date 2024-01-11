using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string UserCpf { get; set; }

    }
}