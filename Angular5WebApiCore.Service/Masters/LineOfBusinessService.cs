using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
    public interface ILineOfBusinessService
    {

    }
    internal class LineOfBusinessService : ILineOfBusinessService
    {
        public LineOfBusinessService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
