using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Accounts
{
	public abstract class AccountBase : AuditableEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
	}
}
