﻿using MediatR;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class GetContractorStockListQuery : IRequest<ContractorStockVm>
    {
        public int page { get; set; }
    }
}
