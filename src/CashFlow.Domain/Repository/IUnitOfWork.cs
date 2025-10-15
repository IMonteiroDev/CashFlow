namespace CashFlow.Domain.Repository;

public interface IUnitOfWork
{
    Task Commit();
}
