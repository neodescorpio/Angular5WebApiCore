using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
	public interface IContactInfoService
	{

	}
	internal class ContactInfoService : IContactInfoService
	{
		public ContactInfoService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
