using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraApiBack.DataAccess.Data
{
    public class ConexionService
    {
        private readonly IConfiguration _configuration;

        public ConexionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string getConexion()
        {
            return _configuration.GetConnectionString("BackendConexion");
        }
    }
}
