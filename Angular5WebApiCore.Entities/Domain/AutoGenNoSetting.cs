using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain
{
	public class AutoGenNoSetting : AuditableEntity
	{
		public AutoGenNoSetting()
		{

		}

		public string EntityName { get; set; }
		public int NoOfDigits { get; set; }
		public string Separator { get; set; }
		public string PreFix { get; set; }
		public string PostFix { get; set; }
	}
}
