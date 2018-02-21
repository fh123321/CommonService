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
        public static IDbConnection CrtConnection(string connStr,string proproviderName ) {
            IDbConnection conn = (IDbConnection) System.Activator.CreateInstance(Type.GetType(proproviderName));
            conn.ConnectionString = connStr;
            return conn;
        }
    }
}