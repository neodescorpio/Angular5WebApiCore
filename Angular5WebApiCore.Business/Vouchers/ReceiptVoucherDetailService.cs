using Angular5WebApiCore.Data;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IReceiptVoucherDetailService
    {
        
    }
    internal class ReceiptVoucherDetailService : IReceiptVoucherDetailService
    {
        private readonly IUnitOfWork unitofWork;
        public ReceiptVoucherDetailService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

    }
}
