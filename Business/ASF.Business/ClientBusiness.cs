using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness
    {
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Add(Client client)
        {
            var clientDac = new ClientDAC();
            return clientDac.Create(client);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var clientDac = new ClientDAC();
            clientDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> All()
        {
            var clientDac = new ClientDAC();
            var result = clientDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client Find(int id)
        {
            var clientDac = new ClientDAC();
            var result = clientDac.SelectById(id);
            return result;
        }

        public Client FindEmail(string email)
        {
            var clientDac = new ClientDAC();
            var result = clientDac.SelectByEmail(email);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public void Edit(Client client)
        {
            var clientDac = new ClientDAC();
            clientDac.UpdateById(client);
        }
    }
}
