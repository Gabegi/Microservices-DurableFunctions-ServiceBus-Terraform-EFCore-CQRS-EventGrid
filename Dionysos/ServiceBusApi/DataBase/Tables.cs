using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataBase
{
    namespace Tables
    {
        public class Customer
        {
            [Key] //Denotes primary key
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string SurName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int Balance { get; set; }
        }

        public class Order
        {
            [Key] //Denotes primary key
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public string WineType { get; set; }
            public string WineName { get; set; }
            public int WineQuantity { get; set; }
            public float WinePrice { get; set; }
            public int TanicLevelOutOfTen { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime LastUpdated { get; set; }
            public string RequestId { get; set; }

        }
    }

}
