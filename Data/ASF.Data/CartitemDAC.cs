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
    public class CartitemDAC : DataAccessComponent
    {
        /// <param name="cartitem"></param>
        /// <returns></returns>
        public CartItem Create(CartItem cartitem)
        {
            const string sqlStatement = "INSERT INTO dbo.CartItem ([CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@CartId, @ProductId, @Price, @Quantity, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cartitem.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cartitem.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cartitem.ChangedBy);
                // Obtener el valor de la primary key.
                cartitem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cartitem;
        }

        /// </summary>
        /// <param name="category"></param>
        public void UpdateById(CartItem cartitem)
        {
            const string sqlStatement = "UPDATE dbo.CartItem " +
                "SET [CartId]=@CartId, " +
                    "[ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cartitem.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cartitem.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cartitem.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cartitem.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.CartItem WHERE [Id]=@Id ";
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
        public CartItem SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.CartItem WHERE [Id]=@Id ";

            CartItem cartitem = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) cartitem = LoadCartItem(dr);
                }
            }

            return cartitem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<CartItem> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.CartItem ";

            var result = new List<CartItem>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var cartitem = LoadCartItem(dr); // Mapper
                        result.Add(cartitem);
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
        private static CartItem LoadCartItem(IDataReader dr)
        {
            var cartitem = new CartItem
            {
                Id = GetDataValue<int>(dr, "Id"),
                CartId = GetDataValue<int>(dr, "CartId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<double>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cartitem;
        }
    }
}
