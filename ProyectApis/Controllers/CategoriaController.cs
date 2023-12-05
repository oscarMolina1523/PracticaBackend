using Aplication.Commands;
using Aplication.Queries;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var categorias = await mediator.Send(new GetAllCategoriaQuery());
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Categoria cat = await mediator.Send(new GetByIdCategoriaQuery(id));
            return Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoriaDto categoria)
        {
            Categoria cat = await mediator.Send(new CreateCategoriaCommand(categoria, Guid.NewGuid()));
            var url = Url.Content("~/") + "api/Categoria/" + cat.Id;
            return Created(url, cat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CategoriaDto categoriaDto)
        {
            Categoria cat = await mediator.Send(new UpdateCategoriaCommand(id, categoriaDto.Descripcion, categoriaDto.Estado));
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await mediator.Send(new DeleteCategoriaCommand(id));
            return Ok();
        }
    }
}
