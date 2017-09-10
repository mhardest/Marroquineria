using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartItemBusiness
    {
        /// <param name="category"></param>
        /// <returns></returns>
        public CartItem Add(CartItem cartitem)
        {
            var cartitemDac = new CartitemDAC();
            return cartitemDac.Create(cartitem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var cartitemDac = new CartitemDAC();
            cartitemDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> All()
        {
            var cartitemDac = new CartitemDAC();
            var result = cartitemDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartItem Find(int id)
        {
            var cartitemDac = new CartitemDAC();
            var result = cartitemDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartitem"></param>
        public void Edit(CartItem cartitem)
        {
            var cartitemDac = new CartitemDAC();
            cartitemDac.UpdateById(cartitem);
        }
    }
}
