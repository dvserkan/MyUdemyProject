using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IRoomService, IRoomManager>();

            services.AddScoped<IStaffDal, EfStaffDal > ();
            services.AddScoped<IStaffService, IStaffManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, ITestimonialManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, IServiceManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, IAboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, IBookingManager>();



        }
    }
}