using IndraApiBack.BusinessLogic.interfaces;
using IndraApiBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndraApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaServices _services;

        public EmpresaController(IEmpresaServices services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<JsonResult> getEmpresas()
        {
            return new JsonResult(await _services.getEmpresas());
        }

        [HttpGet("byId")]
        public async Task<JsonResult> getEmpresabyID(int id)
        {
            return new JsonResult(await _services.getEmpresabyID(id));
        }

        [HttpPost]
        public async Task<JsonResult> InsertEmpresa(Empresa obj)
        {
            return new JsonResult(await _services.InsertEmpresa(obj));
        }

        [HttpPut]
        public async Task<JsonResult> EditEmpres(Empresa obj)
        {
            return new JsonResult(await _services.EditEmpresa(obj));
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCanal(int id)
        {
            return new JsonResult(await _services.DeleteEmpresa(id));
        }
    }
}
