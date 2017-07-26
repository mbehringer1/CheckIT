using System;
using CheckIT.Api.Interfaces;

namespace CheckIT.Api.Classes
{
    public class MoneyToStringResponse : ICheckITResponse
    {
        public string Body { get; set; }
    }
}
