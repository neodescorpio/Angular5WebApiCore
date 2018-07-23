using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Masters
{
    public interface IEmployeeService
	{

	}
	internal class EmployeeService : IEmployeeService
	{
		public EmployeeService(IUnitOfWork unitofWork)
        {
            //this.unitofWork = unitofWork;
        }
    }
}
