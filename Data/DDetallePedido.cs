using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos (DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<DetallePedido> detallepedidos = null;
            try
            {
                comandText = "PC_ListaDetallesPedidos";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.idpedido;
                detallepedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "PC_ListaDetallesPedidos",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallepedidos.Add(new DetallePedido
                        {
                            idpedido = reader["idpedido"] != null ? Convert.ToInt32(reader["idpedido"]) : 0,
                            idproducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            preciounidad = reader["preciounidad"] != null ? Convert.ToInt32(reader["preciounidad"]) : 0,
                            cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            descuento = reader["descuento"] != null ? Convert.ToInt32(reader["descuento"]) : 0
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return detallepedidos;
        }
    }
}
