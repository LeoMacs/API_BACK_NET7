using IndraApiBack.BusinessLogic.interfaces;
using IndraApiBack.DataAccess.Interfaces;
using IndraApiBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraApiBack.BusinessLogic.services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresa _empresaRepository;

        public EmpresaServices(IEmpresa empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }   

        public async Task<dynamic> getEmpresas()
        {
            return await _empresaRepository.getEmpresas();
        }

        public async Task<dynamic> getEmpresabyID(int id)
        {
            return await _empresaRepository.getEmpresabyID(id);
        }

        public async Task<int> InsertEmpresa(Empresa obj)
        {
            return await _empresaRepository.InsertEmpresa(obj);
        }

        public async Task<int> EditEmpresa(Empresa obj)
        {
            return await _empresaRepository.EditEmpresa(obj);
        }

        public async Task<int> DeleteEmpresa(int id)
        {
            return await _empresaRepository.DeleteEmpresa(id);
        }


    }
}
