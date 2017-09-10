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
    class RatingDAC : DataAccessComponent
    {
        /// <param name="rating"></param>
        /// <returns></returns>
        public Rating Create(Rating rating)
        {
            const string sqlStatement = "INSERT INTO dbo.Rating ([ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@ClientId, @ProductId, @Stars, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, rating.ClientId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, rating.ProductId);
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, rating.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, rating.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, rating.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, rating.ChangedBy);
                // Obtener el valor de la primary key.
                rating.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return rating;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rating"></param>
        public void UpdateById(Rating rating)
        {
            const string sqlStatement = "UPDATE dbo.Rating " +
                "SET [ClientId]=@ClientId, " +
                    "[ProductId]=@ProductId, " +
                    "[Stars]=@Stars, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, rating.ClientId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, rating.ProductId);
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, rating.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, rating.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, rating.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, rating.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, rating.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Rating WHERE [Id]=@Id ";
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
        public Rating SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Rating WHERE [Id]=@Id ";

            Rating rating = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) rating = LoadRating(dr);
                }
            }

            return rating;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Rating> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Rating ";

            var result = new List<Rating>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var rating = LoadRating(dr); // Mapper
                        result.Add(rating);
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
        private static Rating LoadRating(IDataReader dr)
        {
            var rating = new Rating
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Stars = GetDataValue<int>(dr, "Stars"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return rating;
        }
    }
}
