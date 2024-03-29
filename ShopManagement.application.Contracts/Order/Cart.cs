﻿using System;
using System.Collections.Generic;

namespace ShopManagement.application.Contracts.Order
{
    public class Cart
    {
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public int PaymentMethod { get; set; }
        public List<CartItem> Items { get; set;}
        public Cart()
        {
            Items = new List<CartItem>();
        }
        public void Add(CartItem cartItem)
        {
            Items.Add(cartItem);
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;
        }

        public void SetPaymentMethod(int paymentMethod)
        {
            this.PaymentMethod=paymentMethod;
        }
    }
}
