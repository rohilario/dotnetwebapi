using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dotnetwebapi.Models
{
    public class Permission
    {
        [Required]
        public int PermissionId { get; set; }
        [Required]
        public string PermissionName { get; set; }
        [Required]
        public string PermissionDescription { get; set; }

    }
}