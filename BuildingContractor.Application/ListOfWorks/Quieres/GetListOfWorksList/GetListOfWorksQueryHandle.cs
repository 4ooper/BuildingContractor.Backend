using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList
{
    public class GetListOfWorksQueryHandle : IRequestHandler<GetListOfWorksQuery, ListOfWorksVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetListOfWorksQueryHandle(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ListOfWorksVm> Handle(GetListOfWorksQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.listOfWorks.Skip(request.page * 15).Take(15).ProjectTo<ListOfWorksLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.listOfWorks.Count() / 15.0).ToString()));
            return new ListOfWorksVm
            {
                listOfWorks = records,
                totalElements = _dbcontext.listOfWorks.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
