using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharpWebApiTest
{
    public class Logs : ActionFilterAttribute
    {

        public Logs()
        {
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {

            var controller = (ControllerBase)context.Controller;

            var action = controller.ControllerContext.ActionDescriptor;


            var arguments = context.ModelState.Aggregate("", (current, val) =>
            {
                var str = current;
                if (str.Length != 0) str += ", ";

                return $"{str} {val.Key}={val.Value?.AttemptedValue}";
            });


            Console.WriteLine(
                "Exécution de l'action : {0}.{1} | idTechPsConnecte : {2} | arguments => {3}", action.ControllerName, action.ActionName, "Slavy", arguments
            );

        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var controller = (ControllerBase)context.Controller;

            var action = controller.ControllerContext.ActionDescriptor;


            var arguments = context.ModelState.Aggregate("", (current, val) =>
            {
                var str = current;
                if (str.Length != 0) str += ", ";

                return $"{str} {val.Key}={val.Value?.AttemptedValue}";
            });

            Console.WriteLine("Fin de l'action : {0}.{1} | idTechPsConnecte : {2} | arguments => {3}",
                action.ControllerName,
                action.ActionName,
                "Slavy",
                arguments
            );
        }
    }
}