using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails;
using BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Commands.DeleteContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialsSearchList;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConctractorMaterialController : BaseController
    {
        private readonly IMapper _mapper;

        public ConctractorMaterialController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ConctractorMaterialVm>> GetAll([FromQuery] int page)
        {
            var query = new GetConctractorMaterialListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<ContractorMaterialSearchListVm>> Search([FromQuery] string searchText)
        {
            var query = new GetContractorMaterialSearchListQuery { searchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ContractorMaterialDetailsVm>> Get(int id)
        {
            var query = new GetContractorMaterialDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromBody] CreateContractorMaterialDto createContractorMaterial)
        {
            try
            {
                var command = _mapper.Map<CreateContractorMaterialCommand>(createContractorMaterial);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContractorMaterialDto updateContractorMaterial)
        {
            var command = _mapper.Map<UpdateContractorMaterialCommand>(updateContractorMaterial);
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
            var command = new DeleteContractorMaterialCommand
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
