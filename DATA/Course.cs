using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Course
    {
        [Key]
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
