namespace ZZTicaret.Application.DTO.Order
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderDetailDTO2> OrderDetails { get; set; } =new List<OrderDetailDTO2>();


    }

    public class OrderDetailDTO2
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string ProductName { get; set; }
    }
}
