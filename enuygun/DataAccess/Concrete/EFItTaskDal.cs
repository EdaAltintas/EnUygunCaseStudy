using Core.ORM.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess.Concrete
{
    public class EFItTaskDal : EfRepositoryBase<ItTask , ToDoContext>, IItTaskDal
    {
    }
}
