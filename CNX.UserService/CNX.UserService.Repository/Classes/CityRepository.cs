using CNX.UserService.Data.Interfaces;
using CNX.UserService.Model.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            //using (StreamReader reader = new StreamReader("../../CNX.UserService/CNX.UserService.WebApi/city.list.json"))
            //{
            //    string citiesJson = reader.ReadToEnd();
            //    _cities = JsonConvert.DeserializeObject<IEnumerable<City>>(citiesJson);
            //}
        }

        //public City FindCityByName(string cityName) => _cities.FirstOrDefault(prop => prop.Name.ToUpper().Equals(cityName.ToUpper()));

        public City FindCityByName(string cityName)
        {
            return findInJson(cityName);
        }

        private const string _citiesJsonPath = "../../CNX.UserService/CNX.UserService.WebApi/city.list.json";
        private City findInJson(string cityName)
        {
            string line, idLine;
            var lookingFor = cityName.AsSpan();
            var nameAsSpan = "/name/:";
            using (var fs = File.OpenRead(_citiesJsonPath))
            using (var reader = new StreamReader(fs))
            while ((line = reader.ReadLine()) != null)
            {
                    var span = line.AsSpan();
                    if (span == null) continue;
                    JObject jObject = null;

                    idLine = line;
            }
            return null;
        }

        public IEnumerable<City> GetAllCities() => _cities;
    }
}
