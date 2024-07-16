using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntitiy
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        //public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
