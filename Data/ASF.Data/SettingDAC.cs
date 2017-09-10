using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    class SettingDAC : DataAccessComponent
    {
        /// <param name="setting"></param>
        /// <returns></returns>
        public Setting Create(Setting setting)
        {
            const string sqlStatement = "INSERT INTO dbo.Setting ([Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Name, @Value, @Description, @LastChangeDate, @WebSiteName, @WebSiteUrl, @PageTitle, @AdminEmailAddress, @SMTP, @SMTPUsername, @SMTPPassword, @SMTPPort, @SMTPEnableSSL, @Theme, @DefaultLanguageId, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime2, setting.LastChangeDate);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, setting.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, setting.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, setting.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, setting.ChangedBy);
                // Obtener el valor de la primary key.
                setting.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public void UpdateById(Setting setting)
        {
            const string sqlStatement = "UPDATE dbo.Setting " +
                "SET [Name]=@Name, " +
                    "[Value]=@Value, " +
                    "[Description]=@Description, " +
                    "[LastChangeDate]=@LastChangeDate, " +
                    "[WebSiteName]=@WebSiteName, " +
                    "[WebSiteUrl]=@WebSiteUrl, " +
                    "[PageTitle]=@PageTitle, " +
                    "[AdminEmailAddress]=@AdminEmailAddress, " +
                    "[SMTP]=@SMTP, " +
                    "[SMTPUsername]=@SMTPUsername, " +
                    "[SMTPPassword]=@SMTPPassword, " +
                    "[SMTPPort]=@SMTPPort, " +
                    "[SMTPEnableSSL]=@SMTPEnableSSL, " +
                    "[Theme]=@Theme, " +
                    "[DefaultLanguageId]=@DefaultLanguageId, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime2, setting.LastChangeDate);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, setting.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, setting.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, setting.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, setting.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, setting.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Setting WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Setting SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Setting WHERE [Id]=@Id ";

            Setting setting = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) setting = LoadSetting(dr);
                }
            }

            return setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Setting> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Setting ";

            var result = new List<Setting>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var setting = LoadSetting(dr); // Mapper
                        result.Add(setting);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>		
        private static Setting LoadSetting(IDataReader dr)
        {
            var setting = new Setting
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                Value = GetDataValue<string>(dr, "Value"),
                Description = GetDataValue<string>(dr, "Description"),
                LastChangeDate = GetDataValue<DateTime>(dr, "LastChangeDate"),
                WebSiteName = GetDataValue<string>(dr, "WebSiteName"),
                WebSiteUrl = GetDataValue<string>(dr, "WebSiteUrl"),
                PageTitle = GetDataValue<string>(dr, "PageTitle"),
                AdminEmailAddress = GetDataValue<string>(dr, "AdminEmailAddress"),
                SMTP = GetDataValue<string>(dr, "SMTP"),
                SMTPUsername = GetDataValue<string>(dr, "SMTPUsername"),
                SMTPPassword = GetDataValue<string>(dr, "SMTPPassword"),
                SMTPPort = GetDataValue<string>(dr, "SMTPPort"),
                SMTPEnableSSL = GetDataValue<bool>(dr, "SMTPEnableSSL"),
                Theme = GetDataValue<string>(dr, "Theme"),
                DefaultLanguageId = GetDataValue<int>(dr, "DefaultLanguageId"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return setting;
        }
    }
}
