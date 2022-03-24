using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Filters
{
    public class ItemExistAttribute: TypeFilterAttribute
    {
        public ItemExistAttribute():base(typeof(ItemExistsFilter))
        {
            
        }
    }
}
