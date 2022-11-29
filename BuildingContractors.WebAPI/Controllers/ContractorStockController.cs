using BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList;
using BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockDetails;
using BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockSearchList;
using BuildingContractor.Application.ContractorStocks.Commands.CreateContractorStock;
using BuildingContractor.Application.ContractorStocks.Commands.UpdateContractorStock;
using BuildingContractor.Application.ContractorStocks.Commands.DeleteContractorStock;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContractorStockController : BaseController
    {
        private readonly IMapper _mapper;
        public ContractorStockController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorStockVm>> GetAll([FromQuery] int page)
        {
            var query = new GetContractorStockListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorStockSearchVm>> Search([FromQuery] string searchText)
        {
            var query = new GetContractorStockSearchListQuery { searchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ContractorStockDetailsVm>> Get(int id)
        {
            var query = new GetContractorStockDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromBody] CreateContractorStockDto createContractorStock)
        {
            try
            {
                var command = _mapper.Map<CreateContractorStockCommand>(createContractorStock);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractorStockDto updateContractorStock)
        {
            var command = _mapper.Map<UpdateContractorStockCommand>(updateContractorStock);
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
            var command = new DeleteContractorStockCommand
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
