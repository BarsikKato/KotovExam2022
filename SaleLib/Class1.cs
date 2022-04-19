using System;

namespace SaleLib
{
    public class Sale
    {
        public static float CalculateSale(int booksCount, float fullCost)
        {
            float sale;
            if (booksCount >= 15)
                sale = 15;
            else if (booksCount >= 10)
                sale = 10;
            else if (booksCount >= 5)
                sale = 5;
            else
                sale = 0;
            if (fullCost > 0)
                sale += (int)fullCost / 500;
            return sale;
        }
    }
}
