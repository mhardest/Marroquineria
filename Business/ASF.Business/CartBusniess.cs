using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartBusniess
    {
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart Add(Cart cart)
        {
            var cartDac = new CartDAC();
            return cartDac.Create(cart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var cartDac = new CartDAC();
            cartDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> All()
        {
            var cartDac = new CartDAC();
            var result = cartDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart Find(int id)
        {
            var cartDac = new CartDAC();
            var result = cartDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        public void Edit(Cart cart)
        {
            var cartDac = new CartDAC();
            cartDac.UpdateById(cart);
        }
    }
}
