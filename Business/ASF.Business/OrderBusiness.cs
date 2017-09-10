using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderBusiness
    {
        /// <param name="category"></param>
        /// <returns></returns>
        public Order Add(Order order)
        {
            var orderDac = new OrderDAC();
            return orderDac.Create(order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var orderDac = new OrderDAC();
            orderDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> All()
        {
            var orderDac = new OrderDAC();
            var result = orderDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Find(int id)
        {
            var orderDac = new OrderDAC();
            var result = orderDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public void Edit(Order order)
        {
            var orderDac = new OrderDAC();
            orderDac.UpdateById(order);
        }
    }
}
