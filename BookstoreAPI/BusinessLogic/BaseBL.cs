using AutoMapper;

namespace BookstoreAPI.BusinessLogic
{
    public abstract class BaseBL<TEntity> where TEntity : class
    {
        protected IMapper Mapper { get; }
        protected BaseBL(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
