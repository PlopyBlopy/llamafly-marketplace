using Domain.DTO;
using FluentValidation;

namespace Shared.Validation.Properties.Category
{
    internal sealed class CategoriesRangeTitlePropValidator : AbstractValidator<List<CreateCategoryDto>>
    {
        public CategoriesRangeTitlePropValidator()
        {
            RuleForEach(categories => categories)
                .ChildRules(category =>
                {
                    category.RuleFor(c => c.Title).SetValidator(new CategoryTitlePropValidator());
                    category.When(c => c.SubCategories.Any(), () => category.RuleFor(x => x.SubCategories).SetValidator(new CategoriesRangeTitlePropValidator()));
                });
        }
    }
}