using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class StudentEntity
    {
        public int StudentID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedOn { get; set; }

        

        
    }
}
