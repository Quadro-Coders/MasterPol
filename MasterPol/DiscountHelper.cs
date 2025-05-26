using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPol
{
    internal class DiscountHelper
    {
        /// <summary>
        /// Рассчет скидки
        /// до 10000 – 0%, 
        /// от 10000 – до 50000 – 5%, 
        /// от 50000 – до 300000 – 10%, 
        /// более 300000 – 15%
        /// </summary>
        /// <param name="sellCount">Количество продаж</param>
        /// <returns>Скидка в процентах</returns>
        public static int Calculate(decimal sellCount)
        {
            switch (sellCount)
            {
                case < 10000:
                    return 0;
                case >= 10000 and < 50000:
                    return 5;
                case >= 50000 and < 300000:
                    return 10;
                case >= 300000:
                    return 15;
            }
        }
    }
}
