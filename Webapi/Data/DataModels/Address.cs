using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Data.DataModels
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }

        public virtual Customer Customers { get; set; }
    }
}
