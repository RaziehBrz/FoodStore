using System;

namespace FoodStore.Data
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime Last_update { get; set; }
        public DateTime Created_At { get; set; }
    }
}