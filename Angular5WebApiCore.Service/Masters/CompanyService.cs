using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
	public interface ICompanyService
	{

	}
	internal class CompanyService : ICompanyService
	{
		public CompanyService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
