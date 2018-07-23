using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Locations
{
	public class Country : LocationBase
	{
		public Country()
		{
			States = new HashSet<State>();
		}

		//public long ID { get; set; }

		//public bool IsDeleted { get; set; }
		//public bool IsActive { get; set; }
		//public DateTime DateCreated { get; set; }
		//public string CreatedBy { get; set; }
		//public DateTime? DateModified { get; set; }
		//public string ModifiedBy { get; set; }

		//public string Name { get; set; }
		//public string Code { get; set; }
		//public string Description { get; set; }

		public virtual ICollection<State> States { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

}
