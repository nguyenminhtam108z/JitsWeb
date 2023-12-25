namespace JitsWebAPI.Models
{
    public class CustomerViewModel
    {
        public Guid CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public int? Sex { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
