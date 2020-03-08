using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboComparer:IComparer<Employee>
    {
        public ComboComparer(IComparer<Employee> firstComparer, IComparer<Employee> secondComparer)
        {
            FirstComparer = firstComparer;
            SecondComparer = secondComparer;
        }

        public IComparer<Employee> FirstComparer { get; private set; }
        public IComparer<Employee> SecondComparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firstCompareResult = FirstComparer.Compare(x, y);
            if (firstCompareResult !=0)
            {
                return firstCompareResult;
            }

            return SecondComparer.Compare(x, y);

            //int finalCompareResult = 0;
            //var firstCompareResult = FirstComparer.Compare(x, y);
            //if (firstCompareResult < 0)
            //{
            //    finalCompareResult = firstCompareResult;
            //    //y = x;
            //    //index = i;
            //}
            //else if (firstCompareResult == 0)
            //{
            //    var secondCompareResult = SecondComparer.Compare(x, y);
            //    if (secondCompareResult < 0)
            //    {
            //        finalCompareResult = secondCompareResult;
            //        //y = x;
            //        //index = i;
            //    }
            //}

            //return finalCompareResult;
        }
    }
}