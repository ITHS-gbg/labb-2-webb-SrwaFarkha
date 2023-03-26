using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class RegisterCustomerAndCreateOrderModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange förnamn!")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange efternamn!")]
        public string LastName { get; set; }
        [Display(Name = "Emailadress")]
        [Required(ErrorMessage = "Du måste ange emailadress!")]
        public string EmailAddress { get; set; }
        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Du måste ange telefonnummer!")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Stad")]
        [Required(ErrorMessage = "Du måste ange stad!")]
        public string City { get; set; }
        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Du måste ange adress!")]
        public string StreetAddress { get; set; }
    }
}
