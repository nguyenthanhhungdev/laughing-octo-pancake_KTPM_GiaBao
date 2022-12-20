using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.DTO
{
    public class Food
    {
        public Food() {}
        public Food(int id, string name, int categoryID, decimal price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["idcategory"];
            this.Price = Convert.ToDecimal(row["price"].ToString());
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
    public class FoodCategory
    {

        public int FoodId;
        public string Name;

        public FoodCategory(int foodId, string name)
        {
            FoodId = foodId;
            Name = name;
        }
        public FoodCategory(DataRow dataRow) : this((int)dataRow["id"], (string)dataRow["name"])
        {
            //DO NOT DELETE
        }
    }
}
