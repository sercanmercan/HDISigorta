namespace HDISigorta.Application.Dtos.Products
{
    public class UpdateProductRequestDto : CreateProductRequestDto
    {
        public Guid Id { get; set; }
    }
}
