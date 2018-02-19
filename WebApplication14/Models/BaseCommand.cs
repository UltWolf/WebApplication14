using CQRSlite.Commands;
using System;


namespace WebApplication14.Models
{
    public class BaseCommand:ICommand
    {
        public Guid Id { get; set; }

        public int ExpectedVersion { get; set; }
    }
}
