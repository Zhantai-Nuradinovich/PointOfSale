using PointOfSale.DataAccess.Models;
using PointOfSale.Models;
using System.Linq;

namespace PointOfSale.Utilities
{
    public static class PriceHelper
    {
        public static double CalculateTotal(PriceInfo[] prices, Purchase purchase)
        {
            var selectedProductsGrouped = purchase.Products.GroupBy(x => x.Code)
                             .Select(x => (x.Key, x.Count()));

            double totalPrice = 0;
            foreach (var selectedProductAndCount in selectedProductsGrouped)
            {
                var selectedCount = selectedProductAndCount.Item2;
                var productPrices = prices.Where(x => x.ProductCode == selectedProductAndCount.Key
                                                   && x.Amount <= selectedCount)
                                          .OrderByDescending(x => x.Amount);

                foreach (var price in productPrices)
                {
                    totalPrice += (selectedCount / price.Amount) * price.PriceValue;
                    selectedCount -= price.Amount;
                }
            }

            purchase.TotalPrice = totalPrice;
            return totalPrice;
        }
    }
}
