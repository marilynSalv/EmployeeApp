using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public class Note
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public string NoteValue { get; set; }
        }

        public class Activity
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public DateTime EndTime { get; set; }
            public int DurationSeconds { get; set; }

        }

        public class Expense : IProperty, IExpense
        {
            public string Name { get; set; }
            public double Cost { get; set; }
        }

        public interface IExpense
        {
            public double Cost { get; set; }
        }


        public interface IMeasurment
        {
            public int Length { get; set; }
        }

        public class Measurement : IProperty, IMeasurment
        {
            public string Name { get; set; }
            public int Length { get; set; }
        }

        public interface IProperty
        {
            public string Name { get; set; }
        }

        public class Item
        {
            public ICollection<Measurement> MeasurmentProperties = new List<Measurement>();

            public ICollection<Expense> ExpenseProperties = new List<Expense>();
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            var x = new Item();
            var li = x.MeasurmentProperties.Select(x => x.Name).ToList(); ;
            return li;
        }
    }
}
