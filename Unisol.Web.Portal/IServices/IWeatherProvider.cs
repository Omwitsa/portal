using System.Collections.Generic;
using Unisol.Web.Portal.Models;

namespace Unisol.Web.Portal.IServices
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
