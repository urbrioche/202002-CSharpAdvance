using Lab.Entities;

namespace Lab
{
    public class ProductPriceValidator:IValidator<Product>
    {
        public bool Validate(Product model)
        {
            return model.Price - model.Cost >= 0;
        }
    }
}