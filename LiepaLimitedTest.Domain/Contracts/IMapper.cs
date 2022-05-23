namespace LiepaLimitedTest.Domain.Contracts
{
    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource source);
    }
}
