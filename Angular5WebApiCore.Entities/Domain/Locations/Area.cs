using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain.Locations
{
	public class Area : LocationBase
	{
		public long CityID { get; set; }
		public virtual City City { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
