using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class RatingBusiness
    {
        /// <param name="rating"></param>
        /// <returns></returns>
        public Rating Add(Rating rating)
        {
            var ratingDac = new RatingDAC();
            return ratingDac.Create(rating);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var ratingDac = new RatingDAC();
            ratingDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> All()
        {
            var ratingDac = new RatingDAC();
            var result = ratingDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rating Find(int id)
        {
            var ratingDac = new RatingDAC();
            var result = ratingDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rating"></param>
        public void Edit(Rating rating)
        {
            var ratingDac = new RatingDAC();
            ratingDac.UpdateById(rating);
        }
    }
}
