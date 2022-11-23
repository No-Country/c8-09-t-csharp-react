using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace CohorteApi.Core.Models.Auth
{
    public class AddRoleToUserModel
    {
        [Required]
        [Email]
        public string UserEmail { get; set; }
        [Required]
        [RegularExpression("user|admin",ErrorMessage ="Invalid role")]
        public string Role { get; set; }
    }
}
