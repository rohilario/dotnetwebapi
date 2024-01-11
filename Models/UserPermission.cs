using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi.Models
{
    public class UserPermission
    {
        [Required]
        public int UserPermissionId { get; set; }

        //FK
        [Required]
        public int UserId { get; set; }

        //FK
        [Required]
        public int PermissionId { get; set; }
           
    }
}