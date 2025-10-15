using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repository.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpenseUseCase : IGetAllExpenseUseCase
    {
        private readonly IExpensesReadonlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllExpenseUseCase(IExpensesReadonlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponsesExpenseJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponsesExpenseJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result),
            };
        }
    }
}
