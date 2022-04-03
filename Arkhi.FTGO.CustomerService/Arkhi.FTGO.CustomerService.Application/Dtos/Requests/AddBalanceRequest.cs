using System.ComponentModel.DataAnnotations;
using Arkhi.FTGO.Libs.Core.DataAnnotations;

namespace Arkhi.FTGO.CustomerService.Application.Dtos.Requests
{
    public class AddBalanceRequest
    {
        [Required] public int Id { get; set; }

        [Required] [Min(0.0)] public decimal Balance { get; set; }
    }
}