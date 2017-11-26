using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderDetailBusiness
    {
        /// <param name="orderdetail"></param>
        /// <returns></returns>
        public OrderDetail Add(OrderDetail orderdetail)
        {
            var orderdetailDac = new OrderDetailDAC();
            return orderdetailDac.Create(orderdetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var orderdetailDac = new OrderDetailDAC();
            orderdetailDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> All()
        {
            var orderdetailDac = new OrderDetailDAC();
            var result = orderdetailDac.Select();
            return result;
        }

        public List<OrderDetail> AllOrder(int OrderId)
        {
            var orderdetailDac = new OrderDetailDAC();
            var result = orderdetailDac.SelectPorOrden(OrderId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDetail Find(int id)
        {
            var orderdetailDac = new OrderDetailDAC();
            var result = orderdetailDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderdetail"></param>
        public void Edit(OrderDetail orderdetail)
        {
            var orderdetailDac = new OrderDetailDAC();
            orderdetailDac.UpdateById(orderdetail);
        }
    }
}
