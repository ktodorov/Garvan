using System;
using System.Collections.Generic;
using System.Text;

namespace Garvan.Entities
{
    public class BasketToSend
    {
        public IEnumerable<ShopObject> ShopObjects { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
