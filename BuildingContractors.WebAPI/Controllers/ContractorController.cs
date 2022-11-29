using BuildingContractor.Application.Contractors.Quieres.GetContractorList;
using BuildingContractor.Application.Contractors.Quieres.GetContractorDetails;
using BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.Contractors.Commands.CreateContractor;
using BuildingContractor.Application.Contractors.Commands.UpdateContractor;
using BuildingContractor.Application.Contractors.Commands.DeleteContractor;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContractorController : BaseController
    {
        private readonly IMapper _mapper;

        public ContractorController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetContractorListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorSearchListVm>> Search([FromQuery] string searchText)
        {
            var query = new GetContractorSearchListQuery { searchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ContractorDetailsVm>> Get(int id)
        {
            var query = new GetContractorDetailsQuery
            {
                id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateContractorDto createContractorDto)
        {
            var command = _mapper.Map<CreateContractorCommand>(createContractorDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractorDto updateContractorDto)
        {
            var command = _mapper.Map<UpdateContractorCommand>(updateContractorDto);
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
            var command = new DeleteContractorCommand
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
