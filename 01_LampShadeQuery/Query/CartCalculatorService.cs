using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_LampShadeQuery.Contracts;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampShadeQuery.Query
{
   public class CartCalculatorService : ICartCalculatorService
    {
        private readonly IAuthHelper _authHelper;
        private readonly DisCountContext _disCountContext;

        public CartCalculatorService(IAuthHelper authHelper, DisCountContext disCountContext)
        {
            _authHelper = authHelper;
            _disCountContext = disCountContext;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();
            var colleagueDiscounts = _disCountContext.colleagueDiscounts
                .Where(x => !x.IsRemoved)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();
            var customerDiscounts = _disCountContext.customerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();

            var currentAccountRole = _authHelper.CurrentAccountRole();
            foreach (var cartItem in cartItems)
            {
                if (currentAccountRole == Roles.ColleagueUser)
                {


                    var colleageDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (colleageDiscount != null)  
                    cartItem.DiscountRate = colleageDiscount.DiscountRate;
                    

                }
            
                else
                {
                    
                        var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                        if (customerDiscount!= null)
                        cartItem.DiscountRate = customerDiscount.DiscountRate;
                                  
                }
                cartItem.DiscountAmount = ((cartItem.TotalItemPrice * cartItem.DiscountRate) / 100);
                cartItem.ItemPayAmount = cartItem.TotalItemPrice - cartItem.DiscountAmount;
                cart.Add(cartItem);
            }
            return cart;
        }
    }
}
