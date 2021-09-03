using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RestaurantMenuSystem.Models;


using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RestaurantMenuSystem.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<AdminMenuModel> adminMenuModels { get; set; }

       
        public DbSet<RestaurantMenuSystem.Models.SignInModel> SignInModel { get; set; }
        public DbSet<RestaurantMenuSystem.Models.SignUpUserModel> SignUpModel { get; set; }

        //internal Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //internal Task Update(AdminMenuModel adminMenuModel)
        //{
        //    throw new NotImplementedException();
        //}

        //internal Task Add(AdminMenuModel adminMenuModel)
        //{
        //    throw new NotImplementedException();
        //}

        //internal Task Delete(AdminMenuModel adminMenuModel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}














    




   
