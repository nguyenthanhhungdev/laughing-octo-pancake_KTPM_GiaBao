using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text.DTO;

namespace text.DAO
{
    internal static class FoodCategoryDAO
    {
        public static List<FoodCategory> getFoodCategories()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM FoodCateGory")
                .AsEnumerable()
                .Select(row => new FoodCategory(row))
                .ToList();
        }
    }
}
