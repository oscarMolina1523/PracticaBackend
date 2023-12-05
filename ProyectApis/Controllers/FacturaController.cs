using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProyectApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IService _service;

        public FacturaController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> createAsync(FacturaDto facturaDto)
        {
           var fact= await _service.createAsync(facturaDto);
           return Ok(fact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsync(Guid Id)
        {
            await _service.DeleteAsync(Id);
            return Ok();
        }
    }
}
