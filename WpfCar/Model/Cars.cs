using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCar.Model
{
    public class Cars
    {

        public int Id { get; set; }
        public string Stamp { get; set; }
        public string Model { get; set; }
        public string StateNumber { get; set; }

        public int EngineType_Id;
        public virtual EngineTypes EngineTypes { get; set; }
    }
}
