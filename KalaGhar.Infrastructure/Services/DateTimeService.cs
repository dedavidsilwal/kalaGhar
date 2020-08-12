using KalaGhar.Application.Common.Interfaces;
using System;

namespace KalaGhar.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
