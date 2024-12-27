using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RestaurantApp_Model.Models
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public Object Data {  get; set; }
    }
}
