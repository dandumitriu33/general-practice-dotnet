using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesLibrary
{
    public class ShoppingCartModel
    {
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionDiscount mentionDiscount,
                                Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal)
        {
            decimal subTotal = Items.Sum(x => x.Price);
            // the method we pass in will be used here - like a variable
            mentionDiscount(subTotal);

            decimal total = calculateDiscountedTotal(Items, subTotal);
            return total;
        }
    }
}
