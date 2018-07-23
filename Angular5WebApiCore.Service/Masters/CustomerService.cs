using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
    public interface ICustomerService
    {

    }
    internal class CustomerService : ICustomerService
    {
        public CustomerService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
