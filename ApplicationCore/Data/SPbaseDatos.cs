using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApIGius.Class
{
    public static class SPbaseDatos
    {
        public static DbCommand LoadStoredProc(this DbContext context, string storedProcName)
        {
            ///<param name="context"> </param>
            ///<param name="storedProcName"> Nombre del procedimiento </param>
            /// <summary> 
            /// Este metodo estatico se encarga de crear la coneccion a la BD para llamar al procedimiento que tiene mas de una relación
            /// </summary>

            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }

        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue)
        {
            ///<param name="cmd"> </param>
            ///<param name="paramName">El nombre del parametro del Proc </param>
            ///<param name="paramValue"> El valor del objeto </param>
            /// <summary> 
            /// Este metodo estatico se encargara de agregar los parametros necesario 
            /// </summary>

            if (string.IsNullOrEmpty(cmd.CommandText))
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
            return cmd;
        }

        private static IList<T> MapToList<T>(this DbDataReader dr)
        {
            /// <summary> 
            /// Este metodo estatico se encargara de mapear los datos relacionados a lista
            /// </summary>
            
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public static IList<T> ExecuteStoredProc<T>(this DbCommand command)
        {
            /// <summary> 
            /// Este metodo estatico se encargara de ejecutar el Proc
            /// </summary>
            /// 
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

     }
}
