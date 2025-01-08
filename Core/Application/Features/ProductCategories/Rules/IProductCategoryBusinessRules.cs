namespace Application.Features.ProductCategories.Rules;

public interface IProductCategoryBusinessRules
{
    Task ProductCategoryNameCanNotBeDubplicated(string name);
}