using Lab.Entities;

namespace Lab
{
    public class ProfitValidator:IValidator<Product>
    {
        public bool Validate(Product model)
        {
            return model.Price > 0;
        }
    }
}