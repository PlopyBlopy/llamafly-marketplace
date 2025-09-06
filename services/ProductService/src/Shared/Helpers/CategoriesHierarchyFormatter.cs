using Domain.DTO;

namespace Shared.Helpers
{
    public sealed class CategoriesHierarchyFormatter
    {
        public List<CategoryWithSubDto> Formate(List<CategoryWithSubDto> flatList)
        {
            if (flatList == null)
                return new List<CategoryWithSubDto>();

            var lookup = flatList.ToLookup(c => c.ParentCategoryId);

            var rootCategories = lookup[null].ToList();

            foreach (var category in flatList)
            {
                category.SubCategories = lookup[category.Id].ToList();
            }
            return rootCategories;
        }

        public List<CategoryWithSubMinDto> Formate(List<CategoryWithSubMinDto> flatList)
        {
            if (flatList == null)
                return new List<CategoryWithSubMinDto>();

            var lookup = flatList.ToLookup(c => c.ParentCategoryId);

            var rootCategories = lookup[null].ToList();

            foreach (var category in flatList)
            {
                category.SubCategories = lookup[category.Id].ToList();
            }
            return rootCategories;
        }
    }
}