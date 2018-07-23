using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain
{
	public class Address : AuditableEntity
	{
		public string Street { get; set; }
		public string Building { get; set; }
		public string Floor { get; set; }
		public string OfficeNo { get; set; }
		public string HouseNo { get; set; }
		public string FlatNo { get; set; }
		public string POBoxNo { get; set; }

		public long? CountryID { get; set; }
		public long? CityID { get; set; }
		public long? AreaID { get; set; }
		public long? CompanyID { get; set; }
		public long? CustomerID { get; set; }
		public long? SupplierID { get; set; }
		public long? EmployeeID { get; set; }
		public long? LineOfBusinessID { get; set; }

		public virtual Locations.Country Country { get; set; }
		public virtual Locations.City City { get; set; }
		public virtual Locations.Area Area { get; set; }
		public virtual Company Company { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Supplier Supplier { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual LineOfBusiness LineOfBusiness { get; set; }
	}
}
