using System.ComponentModel.DataAnnotations;

namespace Arkhi.FTGO.CustomerService.Application.Dtos.Requests
{
    public class ChargeCustomerRequest
    {
        [Required] public int CustomerId { get; set; }

        [Required] public decimal OrderPrice { get; set; }
    }
}