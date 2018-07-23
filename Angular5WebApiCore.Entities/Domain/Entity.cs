using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain
{
	//public interface IEntity
	//{
	//	long ID { get; set; }

	//	bool IsDeleted { get; set; }
	//	bool IsActive { get; set; }
	//	DateTime DateCreated { get; set; }
	//	string CreatedBy { get; set; }
	//	DateTime? DateModified { get; set; }
	//	string ModifiedBy { get; set; }
	//}
	public class AuditableEntity
	{
		public long ID { get; set; }

		public bool IsDeleted { get; set; }
		public bool IsActive { get; set; }
		public DateTime DateCreated { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? DateModified { get; set; }
		public string ModifiedBy { get; set; }

		public override string ToString()
		{
			return Convert.ToString(ID);
		}

		public override int GetHashCode()
		{
			return this.ID.GetHashCode();
		}
	}
}

//namespace Angular5WebApiCore.Models.Domain
//{
//	public interface IBaseEntity<T>
//	{
//		T ID { get; set; }
//	}
//	public interface IEntity : IBaseEntity<long>
//	{
//		bool IsDeleted { get; set; }
//		bool IsActive { get; set; }
//	}

//	public interface IAuditableEntity : IEntity
//	{
//		DateTime DateCreated { get; set; }
//		string CreatedBy { get; set; }

//		DateTime? DateModified { get; set; }
//		string ModifiedBy { get; set; }
//	}

//	public abstract class BaseEntity<T> : IBaseEntity<T>
//	{
//		public virtual T ID { get; set; }
//	}
	
//	public abstract class Entity : BaseEntity<long>, IEntity
//	{

//		public bool IsDeleted { get; set; }
//		public bool IsActive { get; set; }

//		public override string ToString()
//		{
//			return Convert.ToString(ID);
//		}

//		public override int GetHashCode()
//		{
//			return this.ID.GetHashCode();
//		}

//		//public override bool Equals(object model)
//		//{
//		//	return model != null && model is ModelBase && this == (ModelBase)model;
//		//}

//		//public static bool operator ==(ModelBase modelA, ModelBase modelB)
//		//{//}
//		//	if ((modelA == null && modelB != null) || (modelB == null && modelA != null))
//		//		return false;

//		//	bool result = ((object)modelA == null && (object)modelB == null);

//		//	result = (modelA.ID.ToString().ToLower() == modelB.ID.ToString().ToLower());

//		//	//if ((object)modelA == null && (object)modelB == null) result = true;

//		//	//if ((object)modelA == null || (object)modelB == null) result = true;

//		//	//if (modelA.ID.ToString().ToLower() == modelB.ID.ToString().ToLower()) result = true;

//		//	return result;
//		//}
//		//public static bool operator !=(ModelBase modelA, ModelBase modelB)
//		//{
//		//	return (!(modelA == modelB));
//		//}
//	}

//	//public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
//	public abstract class AuditableEntity : Entity, IAuditableEntity
//	{
//		public DateTime DateCreated { get; set; }
//		public string CreatedBy { get; set; }

//		public DateTime? DateModified { get; set; }
//		public string ModifiedBy { get; set; }

//		//public string MetaInfo
//		//{
//		//	get
//		//	{
//		//		string metaInfo = string.Format("Created By {0} on {1}", CreatedBy, DateCreated.ToString("dd MMM yyyy hh:mm:ss"));

//		//		metaInfo += ModifiedBy != null && ModifiedBy.Length > 0 ? " \n Modified By :" + ModifiedBy : "";
//		//		metaInfo += DateModified.HasValue ? " on :" + DateModified.Value.ToString("dd MMM yyyy hh:mm:ss") : "";

//		//		return metaInfo;
//		//	}
//		//}
//	}

//}