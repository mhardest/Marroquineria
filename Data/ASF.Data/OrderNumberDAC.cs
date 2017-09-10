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
    class OrderNumberDAC : DataAccessComponent
    {
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public OrderNumber Create(OrderNumber ordernumber)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderNumber ([Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Number, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.Int32, ordernumber.Number);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, ordernumber.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, ordernumber.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, ordernumber.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, ordernumber.ChangedBy);
                // Obtener el valor de la primary key.
                ordernumber.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return ordernumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordernumber"></param>
        public void UpdateById(OrderNumber ordernumber)
        {
            const string sqlStatement = "UPDATE dbo.OrderNumber " +
                "SET [Number]=@Number, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.String, ordernumber.Number);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, ordernumber.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, ordernumber.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, ordernumber.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, ordernumber.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, ordernumber.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.OrderNumber WHERE [Id]=@Id ";
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
        public OrderNumber SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.OrderNumber WHERE [Id]=@Id ";

            OrderNumber ordernumber = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) ordernumber = LoadOrderNumber(dr);
                }
            }

            return ordernumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<OrderNumber> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.OrderNumber ";

            var result = new List<OrderNumber>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var ordernumber = LoadOrderNumber(dr); // Mapper
                        result.Add(ordernumber);
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
        private static OrderNumber LoadOrderNumber(IDataReader dr)
        {
            var ordernumber = new OrderNumber
            {
                Id = GetDataValue<int>(dr, "Id"),
                Number = GetDataValue<int>(dr, "Number"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return ordernumber;
        }
    }
}
