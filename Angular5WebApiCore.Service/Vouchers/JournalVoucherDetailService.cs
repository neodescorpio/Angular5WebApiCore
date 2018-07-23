using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IJournalVoucherDetailService
    {
        IEnumerable<JournalVoucherDetail> GetAllByVoucherID(long voucherID);
        Task<IEnumerable<JournalVoucherDetail>> GetAllByVoucherIDAsync(long voucherID);
    }
    internal class JournalVoucherDetailService : IJournalVoucherDetailService
    {
        private readonly IUnitOfWork unitofWork;

        public JournalVoucherDetailService(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public IEnumerable<JournalVoucherDetail> GetAllByVoucherID(long voucherID)
        {
            var list = unitofWork.JournalVoucherDetails.GetAll(d => d.JournalVoucherID == voucherID).ToList();
            return list;
        }

        public async Task<IEnumerable<JournalVoucherDetail>> GetAllByVoucherIDAsync(long voucherID)
        {
            var list = await unitofWork.JournalVoucherDetails.GetAll(d => d.JournalVoucherID == voucherID).ToListAsync();
            return list;
        }
    }
}
