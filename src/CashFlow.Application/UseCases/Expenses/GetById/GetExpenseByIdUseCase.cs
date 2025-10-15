using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repository.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IExpensesReadonlyRepository _repository;
        private readonly IMapper _mapper;

        public GetExpenseByIdUseCase(IExpensesReadonlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponsesExpenseJson> Execute(long id)
        {
            var result = await _repository.GetById(id);

            return _mapper.Map<ResponsesExpenseJson>(result);
        }
    }
}
