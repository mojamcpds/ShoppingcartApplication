using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shoppingcart.Controllers
{
    public class StructuremapControllerFactory : DefaultControllerFactory
    {
        //protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        //{
        //    return ObjectFactory.GetInstance(controllerType) as IController;
        //}

        private const string ControllerNotFound = "The controller for path '{0}' could not be found or it does not implement IController.";
        private const string NotAController = "Type requested is not a controller: {0}";
        private const string UnableToResolveController = "Unable to resolve controller: {0}";
        public StructuremapControllerFactory()
        {
            Container = ObjectFactory.Container;
        }
        public IContainer Container { get; set; }
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
                throw new HttpException(404, String.Format(ControllerNotFound, context.HttpContext.Request.Path));

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(NotAController, controllerType.Name), "controllerType");
            try
            {
                controller = Container.GetInstance(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format(UnableToResolveController, controllerType.Name), ex);
            }
            return controller;
        }
    }
}
