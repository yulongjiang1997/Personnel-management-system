using EPMS.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMS.Service.Services
{
    public static class IQuerybleExpansion
    {
        public static IQueryable<T> Pagin<T>(this IQueryable<T> queryable, SelectBaseDto model)
        {
            return queryable.Skip((model.Page - 1) * model.Number).Take(model.Number);
        }
    }
}
