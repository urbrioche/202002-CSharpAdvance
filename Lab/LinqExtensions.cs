using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<Employee> JoeyOrderBy(
            IEnumerable<Employee> employees, 
            IComparer<Employee> comboComparer)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (comboComparer.Compare(elements[i], minElement) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}