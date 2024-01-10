using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class UserPermission
    {
        [Required]
        public int Id { get; set; }

        //FK
        [Required]
        public int UserId { get; set; }

        //FK
        [Required]
        public int PermissionId { get; set; }
           
    }
}