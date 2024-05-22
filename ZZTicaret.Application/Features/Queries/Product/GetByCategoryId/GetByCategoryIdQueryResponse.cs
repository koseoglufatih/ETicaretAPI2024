namespace ZZTicaret.Application.Features.Queries.Product.GetByCategoryId
{
    public class GetByCategoryIdQueryResponse
    {
        public GetByCategoryIdQueryResponse()
        {
            ProductList = new List<Domain.Product>();
        }
        public  List<Domain.Product> ProductList { get; set; }
       
    }
}