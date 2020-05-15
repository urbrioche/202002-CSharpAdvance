using System;
using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySelectManyTests
    {
        [Test]
        public void flat_all_cities_and_sections()
        {
            var cities = new List<City>
            {
                new City {Name = "台北市", Sections = new List<string> {"大同", "大安", "松山"}},
                new City {Name = "新北市", Sections = new List<string> {"三重", "新莊"}},
            };

            var actual = LinqExtensions.JoeySelectMany(cities, city1 => city1.Sections, (city, section) => $"{city.Name}-{section}");

            var expected = new[]
            {
                "台北市-大同",
                "台北市-大安",
                "台北市-松山",
                "新北市-三重",
                "新北市-新莊",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }

    public class City
    {
        public string Name { get; set; }
        public List<string> Sections { get; set; }
    }
}