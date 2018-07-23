using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Accounts
{
	public class AccountType : AccountBase
	{
		public virtual ICollection<AccountGroup> AccountGroups { get; set; }
	}
}
