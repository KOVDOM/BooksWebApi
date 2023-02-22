using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;

namespace BooksWebApi
{
    public class MysqlEntityFrameworkDesignTimeServices:IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection sevicecollection)
        {
            sevicecollection.AddEntityFrameworkMySQL();
            new EntityFrameworkRelationalDesignServicesBuilder(sevicecollection).TryAddCoreServices();
        }
    }
}
