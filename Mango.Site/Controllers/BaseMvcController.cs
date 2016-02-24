using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Mango.BLL;
using Mango.Common.General;

namespace Mango.Site.Controllers
{
    public abstract class BaseMvcController<T, TModel> : Controller
        where T : class, IIdentifier<int>
        where TModel : class, IIdentifier<int>
    {
        protected string[] Includes { get; set; }
        protected readonly IService<T> EntityService;

        protected BaseMvcController(IService<T> entityService)
        {
            EntityService = entityService;
        }

        protected IEnumerable<TModel> GetAll()
        {
            var entities = EntityService.GetAll(Includes);
            return Mapper.Map<IEnumerable<TModel>>(entities);
        }

        protected TModel Get(int id)
        {
            var entity = EntityService.GetByKey(id);
            return Mapper.Map<TModel>(entity);
        }

        protected void CreateItem(TModel value)
        {
            var entity = Mapper.Map<T>(value);
            EntityService.Create(entity);
        }

        public void EditItem(int id, TModel value)
        {
            var result = EntityService.GetByKey(id);
            var entity = Mapper.Map(value, result);
            EntityService.Update(entity);
        }

        public void DeleteItem(int id)
        {
            var result = EntityService.GetByKey(id);
            EntityService.Delete(result);
        }
    }
}
