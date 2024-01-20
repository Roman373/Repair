using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCar.Model
{
    public class Repairs
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int Car_Id;
        public virtual Cars Car { get; set; }
        
        public int ConductWork_Id;
        public virtual ConductWorks ConductWork { get; set; }
        
    }
}
