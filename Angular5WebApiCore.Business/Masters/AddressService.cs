using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
    public interface IAddressService
    {

    }
    internal class AddressService : IAddressService
    {
        public AddressService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
