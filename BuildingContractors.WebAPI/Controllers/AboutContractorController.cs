using BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorList;
using BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorDetails;
using BuildingContractor.Application.AboutContractor.Commands.CreateAboutContractor;
using BuildingContractor.Application.AboutContractor.Commands.UpdateAboutContractor;
using BuildingContractor.Application.AboutContractor.Commands.DeleteAboutContractor;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AboutContractorController : BaseController
    {
        private readonly IMapper _mapper;

        public AboutContractorController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<AboutContractorVm>> GetAll([FromQuery] int page)
        {
            var query = new GetAboutContractorListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<AboutContractorDetailsVm>> Get(int id)
        {
            var query = new GetAboutContractorDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromBody] CreateAboutContractorDto createAboutContractor)
        {
            try
            {
                var command = _mapper.Map<CreateAboutContractorCommand>(createAboutContractor);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAboutContractorDto updateAboutContractor)
        {
            var command = _mapper.Map<UpdateAboutContractorCommand>(updateAboutContractor);
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAboutContractorCommand
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
