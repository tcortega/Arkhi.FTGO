using System.ComponentModel.DataAnnotations;

namespace Arkhi.FTGO.OrderHistoryService.Application.Dtos.Requests
{
    public class CustomerRequest
    {
        [Required] public string Name { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Address { get; set; }
    }
}