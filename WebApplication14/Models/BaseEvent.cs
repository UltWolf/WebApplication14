using System;
using CQRSlite.Events;

namespace WebApplication14.Models
{
     public class BaseEvent : IEvent
    {
        public int Version { get; set; }
       
         DateTimeOffset IEvent.TimeStamp {
            get; set;
        }
        public  Guid Id { get; set; }
    }
}
