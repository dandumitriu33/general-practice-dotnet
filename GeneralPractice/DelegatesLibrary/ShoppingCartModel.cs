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

        public decimal GenerateTotal(MentionDiscount mentionSubTotal,
                                Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
                                Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);
            // the method we pass in will be used here - like a variable
            mentionSubTotal(subTotal);

            tellUserWeAreDiscounting("We are applying your discount.");

            decimal total = calculateDiscountedTotal(Items, subTotal);
            return total;
        }
    }
}
