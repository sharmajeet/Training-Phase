using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Models.Models
{
    public class BaseResponseModel
    {
        public bool succees {  get; set; }
        public string ErrorMessage { get; set; }

        public object Data { get; set; }
    }
}
