using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Леготкин.Interfaces
{
    public interface ITeatr
    {
        void Save(bool Update = false);
        List<Classes.Context.TeatrContext> AllTeatr();
        void Delete();
    }
}
