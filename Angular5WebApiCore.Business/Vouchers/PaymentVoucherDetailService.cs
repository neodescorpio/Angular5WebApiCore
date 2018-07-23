using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IPaymentVoucherDetailService
	{
		Task<IEnumerable<PaymentVoucherDetail>> GetAllByVoucherIDAsync(long voucherID);
	}
	internal class PaymentVoucherDetailService : IPaymentVoucherDetailService
	{
		private readonly IUnitOfWork unitofWork;

		public PaymentVoucherDetailService(IUnitOfWork unitofWork)
		{
			this.unitofWork = unitofWork;
		}

		public async Task<IEnumerable<PaymentVoucherDetail>> GetAllByVoucherIDAsync(long voucherID)
		{
			var list = await unitofWork.PaymentVoucherDetails.GetAll(d => d.PaymentVoucherID == voucherID).ToListAsync();
			return list;
		}
	}
}
