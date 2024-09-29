using DAL.Helper;
using SqlSugar;

namespace DAL
{
    public class SqlSugarDbContext
    {
        private static SqlSugarScope _MainDbContextSqlSugarScope = null;

        /// <summary>
        /// 主数据库上下文操作对象
        /// </summary>
        public static SqlSugarScope MainDbContext
        {
            get
            {
                if (_MainDbContextSqlSugarScope == null)
                {
                    _MainDbContextSqlSugarScope = new SqlSugarScope(new ConnectionConfig()
                    {
                        ConnectionString = ConfigHelper.MainConnectionString,
                        DbType = SetDBType(ConfigHelper.DBType),
                        IsAutoCloseConnection = true,
                        MoreSettings = new ConnMoreSettings()
                        {
                            PgSqlIsAutoToLower = false,
                            PgSqlIsAutoToLowerCodeFirst = false
                        },
                        ConfigureExternalServices = new ConfigureExternalServices()
                        {
                            EntityNameService = (type, entity) =>
                            {
                                var attr = type.GetCustomAttributes(true);
                                if (attr.Any(it => it is SugarTable))
                                {
                                    entity.DbTableName = SetDBType(ConfigHelper.DBType) == DbType.MySql || SetDBType(ConfigHelper.DBType) == DbType.HG ? (attr.First(it => it is SugarTable) as SugarTable).TableName.ToLower() : (attr.First(it => it is SugarTable) as SugarTable).TableName;
                                }
                            }
                        }
                    });
                }
                return _MainDbContextSqlSugarScope;
            }
        }
        public static DbType SetDBType(string dbType)
        {
            DbType DBType;
            switch (dbType.ToLower())
            {
                case "sqlserver":
                    DBType = DbType.SqlServer;
                    break;
                case "mysql":
                    DBType = DbType.MySql;
                    break;
                case "hg":
                    DBType = DbType.HG;
                    break;
                default:
                    DBType = DbType.SqlServer;
                    break;
            }
            return DBType;
        }
    }
}
