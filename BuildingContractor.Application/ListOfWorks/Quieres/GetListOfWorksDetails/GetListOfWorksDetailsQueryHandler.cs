using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksDetails
{
    public class GetListOfWorksDetailsQueryHandler : IRequestHandler<GetListOfWorksDetailsQuery, ListOfWorksDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetListOfWorksDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ListOfWorksDetailsVm> Handle(GetListOfWorksDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.listOfWorks.Include(item => item.license).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(listOfWork), request.id);
            }

            return _mapper.Map<ListOfWorksDetailsVm>(entity);
        }
    }
}
