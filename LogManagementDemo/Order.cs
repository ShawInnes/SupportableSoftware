using System.Collections.Generic;

namespace LogManagementDemo
{
    public class Order
    {
        public int Id { get; set; }

        public Customer Customer { set; get; }
        public List<Item> Items { get; set; }
    }
}