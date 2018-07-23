using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IReceiptVoucherService
    {

    }
    internal class ReceiptVoucherService : IReceiptVoucherService
    {
        private readonly IUnitOfWork unitofWork;

        public ReceiptVoucherService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

    }
}
