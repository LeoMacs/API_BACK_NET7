using IndraApiBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraApiBack.BusinessLogic.interfaces
{
    public interface IEmpresaServices
    {
        public Task<dynamic> getEmpresas();
        public Task<dynamic> getEmpresabyID(int id);
        public Task<int> InsertEmpresa(Empresa obj);
        public Task<int> EditEmpresa(Empresa obj);
        public Task<int> DeleteEmpresa(int id);
    }
}
