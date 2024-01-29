using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndraApiBack.Models;

namespace IndraApiBack.DataAccess.Interfaces
{
     public interface IEmpresa
    {
        public Task<dynamic> getEmpresas();
        public Task<dynamic> getEmpresabyID(int id);
        public Task<int> InsertEmpresa(Empresa obj);
        public Task<int> EditEmpresa(Empresa obj);
        public Task<int> DeleteEmpresa(int id);
    }
}
