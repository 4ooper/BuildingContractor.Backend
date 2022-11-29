using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using BuildingContractor.Domain;
using BuildingContractor.Application.Services.Quieres.GetServicesList;
using BuildingContractor.Application.Services.Quieres.GetServiceDetails;
using BuildingContractor.Application.Services.Commands.CreateService;
using BuildingContractor.Application.Services.Commands.UpdateService;
using BuildingContractor.Application.Services.Commands.DeleteService;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : BaseController
    {
        private readonly IMapper _mapper;

        public ServicesController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ServicesListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetServicesListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ServiceDetailsVm>> Get(int id)
        {
            var query = new GetServiceDetailsQuery
            {
                id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateServiceDto createServiceDto)
        {
            var command = _mapper.Map<CreateServiceCommand>(createServiceDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateServiceDto updateServiceDto)
        {
            var command = _mapper.Map<UpdateServiceCommand>(updateServiceDto);
            try
            {
                await Mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand
            {
                id = id,
            };
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
