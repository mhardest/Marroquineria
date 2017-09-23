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
    public class ProductDAC : DataAccessComponent
    {
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            const string sqlStatement = "INSERT INTO dbo.Product ([Title],[Description] ,[DealerId],[Image],[Price],[QuantitySold],[AvgStars],[Rowid],[CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Title, @Description, @DealerId, @Image, @Price, @QuantitySold, @AvgStars, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@DealerId", DbType.String, product.DealerId);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.String, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.String, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.String, product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.String, product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, product.ChangedBy);
                // Obtener el valor de la primary key.
                product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(Product product)
        {
            const string sqlStatement = "UPDATE dbo.Category " +
                "SET [Title]=@Title, " +
                    "[Description]=@Description, " +
                    "[DealerId]=@DealerId, " +
                    "[Image]=@Image, " +
                    "[Price]=@Price, " +
                    "[QuantitySold]=@QuantitySold, " +
                    "[AvgStars]=@AvgStars, " +
                    "[Rowid]=@Rowid, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, product.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, product.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Product WHERE [Id]=@Id ";
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
        public Product SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Title],[Description] ,[DealerId],[Image],[Price],[QuantitySold],[AvgStars],[Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Product WHERE [Id]=@Id ";

            Product product = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) product = LoadProduct(dr);
                }
            }

            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Product> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Title],[Description] ,[DealerId],[Image],[Price],[QuantitySold],[AvgStars],[Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Product ";

            var result = new List<Product>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var product = LoadProduct(dr); // Mapper
                        result.Add(product);
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
        private static Product LoadProduct(IDataReader dr)
        {
            var product = new Product
            {
                Id = GetDataValue<int>(dr, "Id"),
                Title = GetDataValue<string>(dr, "Title"),
                Description = GetDataValue<string>(dr, "Description"),
                DealerId = GetDataValue<int>(dr, "DealerId"),
                Image = GetDataValue<string>(dr, "Image"),
                Price = GetDataValue<double>(dr, "Price"),
                QuantitySold = GetDataValue<int>(dr, "QuantitySold"),
                AvgStars = GetDataValue<double>(dr, "AvgStars"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return product;
        }
    }
}
