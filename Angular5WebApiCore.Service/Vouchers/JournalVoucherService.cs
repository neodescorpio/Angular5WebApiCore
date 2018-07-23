using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Vouchers
{
    public interface IJournalVoucherService
    {
        JournalVoucher Get(string voucherNo);
        IEnumerable<JournalVoucher> GetAll(string voucherNo);

        Task<JournalVoucher> GetAsync(string voucherNo);
        Task<IEnumerable<JournalVoucher>> GetAllAsync(string voucherNo);
    }
    internal class JournalVoucherService : IJournalVoucherService
    {
        private readonly IUnitOfWork unitofWork;

        public JournalVoucherService(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public JournalVoucher Get(string voucherNo)
        {
            var entity = unitofWork.JournalVouchers.Get(d => d.Number == voucherNo);
            return entity;
        }
        public IEnumerable<JournalVoucher> GetAll(string voucherNo)
        {
            var list = unitofWork.JournalVouchers.GetAll(d => d.Number == voucherNo);
            return list;
        }
        public async Task<JournalVoucher> GetAsync(string voucherNo)
        {
            var entity = await unitofWork.JournalVouchers.GetAsync(d => d.Number == voucherNo);
            return entity;
        }
        public async Task<IEnumerable<JournalVoucher>> GetAllAsync(string voucherNo)
        {
            var list = await unitofWork.JournalVouchers.GetAll(d => d.Number == voucherNo).ToListAsync();
            return list;
        }
    }
}
