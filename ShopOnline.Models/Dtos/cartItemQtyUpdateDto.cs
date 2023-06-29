using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Dtos
{
    public class cartItemQtyUpdateDto
    {
        public int CartItemId { get; set; }
        public int Qty { get; set; }
    }
}
