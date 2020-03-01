using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class MyOrderedEnumerable
    {
        public static IEnumerable<Employee> JoeySort(this IEnumerable<Employee> employees, IComparer<Employee> comboCompare)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];

                    if (comboCompare.Compare(employee, minElement) < 0)
                    {
                        minElement = employee;
                        index = i;
                    }


                }

                elements.RemoveAt(index);
                yield return minElement;
            }

        }
    }
}