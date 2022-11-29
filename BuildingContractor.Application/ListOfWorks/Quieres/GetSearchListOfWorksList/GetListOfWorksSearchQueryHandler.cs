using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetSearchListOfWorksList
{
    public class GetListOfWorksSearchQueryHandler : IRequestHandler<GetListOfWorksSearchQuery, SearchListOfWorksVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;
        public GetListOfWorksSearchQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<SearchListOfWorksVm> Handle(GetListOfWorksSearchQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.listOfWorks.Where(item => item.name.Contains(request.searchText)).ProjectTo<ListOfWorksLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new SearchListOfWorksVm
            {
                listOfWorks = records
            };
        }
    }
}
