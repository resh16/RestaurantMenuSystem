using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuSystem.Models
{
    public class AdminMenuModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]

        public IFormFile ImageFile { get; set; }

        

        public int Price { get; set; }

        public string Description { get; set; }
        //public string ImageName { get;  set; }
    }
}
