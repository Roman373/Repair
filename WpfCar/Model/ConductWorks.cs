using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCar.Model
{
    public class ConductWorks
    {
        public int Id { get; set; }
        public string NameWork { get; set; }

        public int EngineType_Id;
        public virtual EngineTypes EngineType { get; set; }
    }
}
