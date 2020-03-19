using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Services
{
    public class MyClass
    {

        static public T Mapp<T>(object Obj) where T : IBaseEntity, INamedEntity, IOrderedEntity, new()
        {
            if (Obj is IBaseEntity && Obj is INamedEntity && Obj is IOrderedEntity)
            {
                T _obj = new T
                {
                    Id = ((IBaseEntity)Obj).Id,
                    Name = ((INamedEntity)Obj).Name,
                    Order = ((IOrderedEntity)Obj).Order
                };

                return _obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}
