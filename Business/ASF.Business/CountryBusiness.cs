using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CountryBusiness
    {
        /// <param name="category"></param>
        /// <returns></returns>
        public Country Add(Country country)
        {
            var countryDac = new CountryDAC();
            return countryDac.Create(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var countryDac = new CountryDAC();
            countryDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> All()
        {
            var countryDac = new CountryDAC();
            var result = countryDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Find(int id)
        {
            var countryDac = new CountryDAC();
            var result = countryDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        public void Edit(Country country)
        {
            var countryDac = new CountryDAC();
            countryDac.UpdateById(country);
        }
    }
}
