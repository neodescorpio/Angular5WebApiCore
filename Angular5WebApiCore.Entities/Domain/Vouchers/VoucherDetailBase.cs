using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Vouchers
{
	public abstract class VoucherDetailBase : AuditableEntity
	{
		public long AccountID { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public string Narration { get; set; }
		
		public virtual Accounts.AccountTitle Account { get; set; }
	}
}
