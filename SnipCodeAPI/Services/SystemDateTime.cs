using SnipCodeAPI.Services.Interfaces;
using System;

namespace SnipCodeAPI.Services
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
