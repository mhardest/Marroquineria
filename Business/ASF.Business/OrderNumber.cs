using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderNumberBusiness
    {
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public OrderNumber Add(OrderNumber ordernumber)
        {
            var ordernumberDac = new OrderNumberDAC();
            return ordernumberDac.Create(ordernumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var ordernumberDac = new OrderNumberDAC();
            ordernumberDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> All()
        {
            var ordernumberDac = new OrderNumberDAC();
            var result = ordernumberDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderNumber Find(int id)
        {
            var ordernumberDac = new OrderNumberDAC();
            var result = ordernumberDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordernumber"></param>
        public void Edit(OrderNumber ordernumber)
        {
            var ordernumberDac = new OrderNumberDAC();
            ordernumberDac.UpdateById(ordernumber);
        }
    }
}
