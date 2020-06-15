using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.BusinessLogic
{
    public interface ILogicBL
    {
        int Calculate(List<ItemsDTO> objItems);
    }
}
