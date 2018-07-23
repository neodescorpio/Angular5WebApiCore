using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Angular5WebApiCore.Service
{
    public interface IAutoGenNoSettingService : IService<AutoGenNoSetting>
    {
        AutoGenNoSetting Get(Expression<Func<AutoGenNoSetting, bool>> filter, params string[] includeProperties);
        IQueryable<AutoGenNoSetting> GetAll(Expression<Func<AutoGenNoSetting, bool>> filter = null, Func<IQueryable<AutoGenNoSetting>, IOrderedQueryable<AutoGenNoSetting>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
    }
    internal class AutoGenNoSettingService : ServiceBase<AutoGenNoSetting>, IAutoGenNoSettingService
    {
        private readonly IUnitOfWork unitofWork;

        public AutoGenNoSettingService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public IQueryable<AutoGenNoSetting> GetAll(Expression<Func<AutoGenNoSetting, bool>> filter = null, Func<IQueryable<AutoGenNoSetting>, IOrderedQueryable<AutoGenNoSetting>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            var list = new List<AutoGenNoSetting>() {
                new AutoGenNoSetting() { EntityName="JournalVoucher", NoOfDigits=6, PostFix=null, PreFix="JV", Separator="-", IsActive=true }, //CreatedBy=1, DateCreated=DateTime.Now },
				new AutoGenNoSetting() { EntityName="PaymentVoucher", NoOfDigits=6, PostFix=null, PreFix="PV", Separator="-", IsActive=true }, //CreatedBy=1, DateCreated=DateTime.Now },
				new AutoGenNoSetting() { EntityName="ReceiptVoucher", NoOfDigits=6, PostFix=null, PreFix="RV", Separator="-", IsActive=true } //,CreatedBy=1, DateCreated=DateTime.Now }
			};
            return list.AsQueryable().Where(filter);
        }

        public AutoGenNoSetting Get(Expression<Func<AutoGenNoSetting, bool>> filter, params string[] includeProperties)
        {
            var entity = GetAll(filter).FirstOrDefault();
            return entity;
        }
    }
}
