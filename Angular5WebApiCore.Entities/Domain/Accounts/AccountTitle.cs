using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Accounts
{
	public class AccountTitle : AccountBase
	{
		public long AccountSubGroupID { get; set; }
		public virtual AccountSubGroup AccountSubGroup { get; set; }
	}
}
