using ECommerceProjBusiness.Repositories;
using ECommerceProjBusiness.Services;
using ECommerceProjData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProjEntities.DependenceInjections
{
    public static class StaticInjecDependence
    {
        public static void DependenceInject(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductService>();
            services.AddScoped<IImagesRepository, ImageService>();
        }
    }
}
