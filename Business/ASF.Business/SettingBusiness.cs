using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class SettingBusiness
    {
        /// <param name="setting"></param>
        /// <returns></returns>
        public Setting Add(Setting setting)
        {
            var settingDac = new SettingDAC();
            return settingDac.Create(setting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var settingDac = new SettingDAC();
            settingDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Setting> All()
        {
            var settingDac = new SettingDAC();
            var result = settingDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Setting Find(int id)
        {
            var settingDac = new SettingDAC();
            var result = settingDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public void Edit(Setting setting)
        {
            var settingDac = new SettingDAC();
            settingDac.UpdateById(setting);
        }
    }
}
