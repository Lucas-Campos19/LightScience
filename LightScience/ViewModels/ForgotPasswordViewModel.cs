using System.ComponentModel.DataAnnotations;

namespace LightScience.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }   
    }
}
