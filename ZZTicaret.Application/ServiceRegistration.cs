using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ZZTicaret.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection collection)
        {

            collection.AddMediatR(typeof(ServiceRegistration));
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());



        }
    }
}
