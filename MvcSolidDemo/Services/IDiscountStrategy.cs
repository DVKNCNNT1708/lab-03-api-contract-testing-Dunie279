using MvcSolidDemo.Models;

namespace MvcSolidDemo.Services
{
    // Interface chiến lược giảm giá
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double originalPrice);
    }

    // Class Không giảm giá
    public class DefaultDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double originalPrice) => originalPrice;
    }

    // Class Xả kho giảm 20%
    public class ClearanceDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double originalPrice) => originalPrice * 0.8;
    }
}