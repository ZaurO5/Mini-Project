﻿using ConsoleCommerceApp.Core.Entities;
namespace Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
