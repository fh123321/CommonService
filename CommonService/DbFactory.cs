using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonService
{
    public class DbFactory
    {
        //這邊是DB工廠可以做一些DB加解密與產出DB的相關功能
        //注意在Config 的 providerName 必須完整來
        //<add name="OOXX" connectionString="XXXXXX" providerName="System.Data.SqlClient.SqlConnection, version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
        public static IDbConnection CrtConnection(string connStr,string proproviderName ) {
            IDbConnection conn = (IDbConnection) System.Activator.CreateInstance(Type.GetType(proproviderName));
            conn.ConnectionString = connStr;
            return conn;
        }
    }
}
