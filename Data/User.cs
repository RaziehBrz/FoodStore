using System;
using System.Collections.Generic;

namespace FoodStore.Data
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IdAdmin { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> payments { get; set; }
    }
}