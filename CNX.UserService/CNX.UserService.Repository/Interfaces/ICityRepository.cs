using CNX.UserService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Data.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAllCities();
        City FindCityByName(string cityName);
    }
}
