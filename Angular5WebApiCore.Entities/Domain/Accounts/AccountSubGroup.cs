using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Accounts
{
	public class AccountSubGroup : AccountBase
	{
		public long AccountGroupID { get; set; }
		public virtual AccountGroup AccountGroup { get; set; }

		public virtual ICollection<AccountTitle> AccountTitles { get; set; }
	}
}
