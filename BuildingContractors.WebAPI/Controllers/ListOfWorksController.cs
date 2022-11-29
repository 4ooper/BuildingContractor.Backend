using BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList;
using BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksDetails;
using BuildingContractor.Application.ListOfWorks.Quieres.GetSearchListOfWorksList;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.ListOfWorks.Commands.CreateListOfWorks;
using BuildingContractor.Application.ListOfWorks.Commands.UpdateListOfWorks;
using BuildingContractor.Application.ListOfWorks.Commands.DeleteListOfWorks;
using BuildingContractor.WebAPI.Models;
using AutoMapper;


namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ListOfWorksController : BaseController
    {
        private readonly IMapper _mapper;

        public ListOfWorksController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ListOfWorksVm>> GetAll([FromQuery] int page)
        {
            var query = new GetListOfWorksQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<SearchListOfWorksVm>> Search([FromQuery] string searchText)
        {
            var query = new GetListOfWorksSearchQuery { searchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<ListOfWorksDetailsVm>> Get(int id)
        {
            var query = new GetListOfWorksDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromBody] CreateListOfWorkDto createListOfWorkDto)
        {
            var command = _mapper.Map<CreateListOfWorkCommand>(createListOfWorkDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateListOfWorkDto updateListOfWorkDto)
        {
            var command = _mapper.Map<UpdateListOfWorkCommand>(updateListOfWorkDto);
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
            var command = new DeleteListOfWorkCommad
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
