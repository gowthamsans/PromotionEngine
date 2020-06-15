using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class ItemsDTO
    {
        #region Private Properties

        private int _discountedPriceA = 130;

        private int _discountedQunatityA = 3;

        private int _discountedPriceB = 45;

        private int _discountedQuantityB = 2;

        private int _discountedQuantityCD = 2;

        private int _discountedPriceCD = 30;
        #endregion

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int Total { get; set; }

        public int DiscountedPriceOfA
        {
            get
            {
                return _discountedPriceA;
            }
            set
            {
                value = _discountedPriceA;
            }
        }

        public int DiscountedQuantityA
        {
            get
            {
                return _discountedQunatityA;
            }
            set
            {
                value = _discountedQunatityA;
            }
        }

        public int DiscountedPriceOfB
        {
            get
            {
                return _discountedPriceB;
            }
            set
            {
                value = _discountedPriceB;
            }
        }

        public int DiscountedQuantityB
        {
            get
            {
                return _discountedQuantityB;
            }
            set
            {
                value = _discountedQuantityB;
            }
        }

        public int DiscountedPriceOfCD
        {
            get
            {
                return _discountedPriceCD;
            }
            set
            {
                value = _discountedPriceCD;
            }
        }

        public int DiscountedQuantityCD
        {
            get
            {
                return _discountedQuantityCD;
            }
            set
            {
                value = _discountedQuantityCD;
            }
        }
    }
}
