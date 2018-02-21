using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace CommonService
{
    public class StaticService
    {
        public static Dictionary<Type, DbType> typeMap = new Dictionary<Type, DbType>() {
            {typeof(byte) , DbType.Byte},
            {typeof(sbyte) , DbType.SByte},
            {typeof(short) , DbType.Int16},
            {typeof(ushort) , DbType.UInt16},
            {typeof(int) , DbType.Int32},
            {typeof(uint) , DbType.UInt32},
            {typeof(long) , DbType.Int64},
            {typeof(ulong) , DbType.UInt64},
            {typeof(float) , DbType.Single},
            {typeof(double) , DbType.Double},
            {typeof(decimal) , DbType.Decimal},
            {typeof(bool) , DbType.Boolean},
            {typeof(string) , DbType.String},
            {typeof(char) , DbType.StringFixedLength},
            {typeof(Guid) , DbType.Guid},
            {typeof(DateTime) , DbType.DateTime},
            {typeof(DateTimeOffset) , DbType.DateTimeOffset},
            {typeof(byte[]) , DbType.Binary},
            {typeof(byte?) , DbType.Byte},
            {typeof(sbyte?) , DbType.SByte},
            {typeof(short?) , DbType.Int16},
            {typeof(ushort?) , DbType.UInt16},
            {typeof(int?) , DbType.Int32},
            {typeof(uint?) , DbType.UInt32},
            {typeof(long?) , DbType.Int64},
            {typeof(ulong?) , DbType.UInt64},
            {typeof(float?) , DbType.Single},
            {typeof(double?) , DbType.Double},
            {typeof(decimal?) , DbType.Decimal},
            {typeof(bool?) , DbType.Boolean},
            {typeof(char?) , DbType.StringFixedLength},
            {typeof(Guid?) , DbType.Guid},
            {typeof(DateTime?) , DbType.DateTime},
            {typeof(DateTimeOffset?) , DbType.DateTimeOffset},
         //   {typeof(System.Data.Linq.Binary) , DbType.Binary}
            };

        public static string CryptographyPassword(string password, string salt)
        {
            string cryptographyPassword =
                FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
            return cryptographyPassword;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public static bool IsPropHasValue(object src, string propName) {
            if (src == null) return false;
            return src.GetType().GetProperty(propName).GetValue(src, null) != null;
        }
        public static DbType? GetDbType(Type type) {
            if (typeMap.Where(t => t.Key == type).Count() == 1) {
                DbType? dbType = typeMap.Where(t => t.Key == type).Select(t => t.Value).Single();
                return dbType;
            }
            return null;
        }
    }
}