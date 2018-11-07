using System;
using System.Collections.Generic;
using System.Text;
using Garvan.Resources;

namespace Garvan.Entities
{
    public class ShopObject
    {
        public int Count { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Resources.Resources.Object}: {Name}, {Resources.Resources.Count}: {Count}, {Resources.Resources.PricePerUnit}: {Price}";
        }
    }
}
