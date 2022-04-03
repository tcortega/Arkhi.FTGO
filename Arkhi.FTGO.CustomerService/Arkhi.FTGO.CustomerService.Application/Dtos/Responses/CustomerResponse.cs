namespace Arkhi.FTGO.CustomerService.Application.Dtos.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
    }
}