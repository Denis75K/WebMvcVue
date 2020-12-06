using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebMvcVue.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cityies = new[]
        {
            "Москва", "Новгород", "Тула", "Калуга", "Тверь", "Белгород", "Калининград", "Ярославль", "Брянск", "Севатополь"
        };

        public class WeatherForecast
        {
            public int Id { get; set; }
            public string City { get; set; }
            public string Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public string Get()
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var rng = new Random();

            var forecasts=new List<WeatherForecast>();

            for (int i = 0; i < Summaries.Length; i++)
            {
                var forecast = new WeatherForecast
                {
                    Id = ++i,
                    City = Cityies[i],
                    Date = DateTime.Now.AddDays(rng.Next(0, 30)).ToString("dd.MM.yyyy"),
                    Summary = Summaries[i],
                    TemperatureC = rng.Next(-20, 55)
                };

                forecasts.Add(forecast);
            }

            return serializer.Serialize(forecasts);
        }

        public class Color
        {
            public string Title { get; set; }
            public string Value { get; set; }
        }

        [HttpGet]
        public string Colors()
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var items = new List<Color>()
            {
                new Color{Title = "Красный", Value = "#c63111"},
                new Color{Title = "Зеленый", Value = "#28b463"},
                new Color{Title = "Желтый", Value = "#DFFF00 "}
            };

            

            return serializer.Serialize(items);
        }
    }
}