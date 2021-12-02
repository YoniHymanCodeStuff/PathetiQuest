using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTempUI.Model
{
    public interface IDeepcloneable<T>
    {
        T CreateDeepCopy();
    }
}
//this might be garbage... 