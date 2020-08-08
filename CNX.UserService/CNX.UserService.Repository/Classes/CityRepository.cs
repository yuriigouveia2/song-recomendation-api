using CNX.UserService.Data.Interfaces;
using CNX.UserService.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CNX.UserService.Data.Classes
{
    public class CityRepository : ICityRepository
    {
        private IEnumerable<City> _cities = new City[] { };

        public CityRepository()
        {
            using (StreamReader reader = new StreamReader("../../CNX.UserService/CNX.UserService.WebApi/city.list.json"))
            {
                string citiesJson = reader.ReadToEnd();
                _cities = JsonConvert.DeserializeObject<IEnumerable<City>>(citiesJson);
            }
        }

        public City FindCityByName(string cityName) => _cities.FirstOrDefault(prop => prop.Name.ToUpper().Equals(cityName.ToUpper()));

        public IEnumerable<City> GetAllCities() => _cities;
    }
}
