using BuildingContractor.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Domain;
using BuildingContractor.Application.Licenses.Quieres.GetLicenseList;
using BuildingContractor.Application.Licenses.Quieres.GetLicenseDetails;
using BuildingContractor.Application.Licenses.Quieres.GetLicenseSearchList;
using BuildingContractor.Application.Licenses.Commands.CreateLicense;
using BuildingContractor.Application.Licenses.Commands.UpdateLicense;
using BuildingContractor.Application.Licenses.Commands.DeleteLicense;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LicensesController : BaseController
    {
        private readonly IMapper _mapper;
        public LicensesController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<LicenseListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetLicenseListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<LicenseListVm>> Search([FromQuery] int searchText)
        {
            var query = new GetLicenseSearchListQuery { searchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<LicenseDetailsVm>> Get(int id)
        {
            var query = new GetLicenseDetailsQuery
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
        public async Task<ActionResult<License>> Create([FromBody] CreateLicenseDto createLicenseDto)
        {
            var command = _mapper.Map<CreateLicenseCommand>(createLicenseDto);
            var note = await Mediator.Send(command);
            return Ok(note);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLicenseDto updateLicenseDto)
        {
            var command = _mapper.Map<UpdateLicenseCommand>(updateLicenseDto);
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
            var command = new DeleteLicenseCommand
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
