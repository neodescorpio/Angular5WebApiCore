using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
    public interface ISupplierService
    {

    }
    internal class SupplierService : ISupplierService
    {
        public SupplierService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
