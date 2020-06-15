using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromotionEngine.Models;

namespace PromotionEngine.BusinessLogic
{
    public class LogicBL : ILogicBL
    {
        public int Calculate(List<ItemsDTO> objItems)
        {
            int total = 0;

            if (objItems.Count >= 1)
            {
                bool IsCExist = objItems.Any(name => name.Name == "C");
                bool IsDExist = objItems.Any(name => name.Name == "D");

                if (IsCExist && IsDExist)
                {
                   total = CalculationOfCombinedProduct(objItems);
                }
                else
                {
                    total = CalculationOfNotCombinedProduct(objItems);
                }
            }
            
            return total;
        }

        private int CalculationOfNotCombinedProduct(List<ItemsDTO> objItems)
        {
            int total = 0;

            foreach (ItemsDTO obj in objItems)
            {
                switch (obj.Name)
                {
                    case "A":
                        if (obj.Quantity % obj.DiscountedQuantityA == 0)
                        {
                            int discountedPiece = obj.Quantity / obj.DiscountedQuantityA;
                            obj.Total = discountedPiece * obj.DiscountedPriceOfA;
                        }
                        else
                        {
                            if (obj.Quantity >= obj.DiscountedQuantityA)
                            {
                                int discountedPiece = obj.Quantity / obj.DiscountedQuantityA;
                                obj.Total = discountedPiece * obj.DiscountedPriceOfA;
                                obj.Quantity = obj.Quantity - (discountedPiece * obj.DiscountedQuantityA);
                                obj.Total = obj.Total + (obj.Quantity * obj.Price);
                            }
                            else
                            {
                                obj.Total = obj.Quantity * obj.Price;
                            }
                        }
                        break;
                    case "B":
                        if (obj.Quantity % obj.DiscountedQuantityB == 0)
                        {
                            int discountedPiece = obj.Quantity / obj.DiscountedQuantityB;
                            obj.Total = discountedPiece * obj.DiscountedPriceOfB;
                        }
                        else
                        {
                            if (obj.Quantity >= obj.DiscountedQuantityB)
                            {
                                int discountedPiece = obj.Quantity / obj.DiscountedQuantityB;
                                obj.Total = discountedPiece * obj.DiscountedPriceOfB;
                                obj.Quantity = obj.Quantity - (discountedPiece * obj.DiscountedQuantityB);
                                obj.Total = obj.Total + (obj.Quantity * obj.Price);
                            }
                            else
                            {
                                obj.Total = obj.Quantity * obj.Price;
                            }
                        }
                        break;
                    case "C":
                        obj.Total = obj.Quantity * obj.Price;
                        break;
                    case "D":
                        obj.Total = obj.Quantity * obj.Price;
                        break;
                }
            }

            foreach (ItemsDTO obj in objItems)
            {
                total += obj.Total;
            }

            return total;
        }

        private int CalculationOfCombinedProduct(List<ItemsDTO> objItems)
        {
            int total = 0;

            foreach (ItemsDTO obj in objItems)
            {
                switch (obj.Name)
                {
                    case "A":
                        if (obj.Quantity % obj.DiscountedQuantityA == 0)
                        {
                            int discountedPiece = obj.Quantity / obj.DiscountedQuantityA;
                            obj.Total = discountedPiece * obj.DiscountedPriceOfA;
                        }
                        else
                        {
                            if (obj.Quantity >= obj.DiscountedQuantityA)
                            {
                                int discountedPiece = obj.Quantity / obj.DiscountedQuantityA;
                                obj.Total = discountedPiece * obj.DiscountedPriceOfA;
                                obj.Quantity = obj.Quantity - (discountedPiece * obj.DiscountedQuantityA);
                                obj.Total = obj.Total + (obj.Quantity * obj.Price);
                            }
                            else
                            {
                                obj.Total = obj.Quantity * obj.Price;
                            }
                        }
                        break;
                    case "B":
                        if (obj.Quantity % obj.DiscountedQuantityB == 0)
                        {
                            int discountedPiece = obj.Quantity / obj.DiscountedQuantityB;
                            obj.Total = discountedPiece * obj.DiscountedPriceOfB;
                        }
                        else
                        {
                            if (obj.Quantity >= obj.DiscountedQuantityB)
                            {
                                int discountedPiece = obj.Quantity / obj.DiscountedQuantityB;
                                obj.Total = discountedPiece * obj.DiscountedPriceOfB;
                                obj.Quantity = obj.Quantity - (discountedPiece * obj.DiscountedQuantityB);
                                obj.Total = obj.Total + (obj.Quantity * obj.Price);
                            }
                            else
                            {
                                obj.Total = obj.Quantity * obj.Price;
                            }
                        }
                        break;
                }
            }

            int cCount = objItems.Where(item => item.Name.ToUpper() == "c".ToUpper()).Count();
            int dCount = objItems.Where(item => item.Name.ToUpper() == "D".ToUpper()).Count();

            if ((cCount + dCount) % 2 == 0)
            {
                int discountedPiece = (cCount + dCount) / 2;
                total = discountedPiece * 30;
            }
            else
            {
                int cPrice = 0;
                int dPrice = 0;

                foreach (ItemsDTO obj in objItems)
                {
                    if (obj.Name == "C")
                        cPrice = obj.Price;
                    else if (obj.Name == "D")
                        dPrice = obj.Price;
                }       

                    if (cCount > dCount)
                    {
                        int cRem = cCount / dCount;
                        int discountedPiece = (cCount + dCount) / 2;
                        total = discountedPiece * 30;
                        total = total + (cRem * cPrice);
                    }
                    else
                    {
                        int dRem = dCount / cCount;
                        int discountedPiece = (cCount + dCount) / 2;
                        total = discountedPiece * 30;
                        total = total + (dRem * cPrice);    
                    }
            }

            foreach (ItemsDTO obj in objItems)
            {
                total += obj.Total;
            }

            return total;
        }
    }
}
