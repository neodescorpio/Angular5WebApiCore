using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IPaymentVoucherService
	{

	}
	internal class PaymentVoucherService : IPaymentVoucherService
	{
		private readonly IUnitOfWork unitofWork;

		public PaymentVoucherService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
	}
}
