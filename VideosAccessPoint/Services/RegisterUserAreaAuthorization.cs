using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAccessPoint.Services
{
    public class RegisterUserAreaAuthorization : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public RegisterUserAreaAuthorization(string area,string policy)
        {
            _area = area;
            _policy = policy;
        }
        public void Apply(ControllerModel controller)
        {
            if(controller.Attributes.Any(a=>
            a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
