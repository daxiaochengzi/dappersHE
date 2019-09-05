using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.ModelTest
{
    public abstract class TestAbstractSuper
    {
        public virtual  int CreateAsync(int Id)
        {
            return Id;
        }
        public string Hello()
        {
            return "123";
        }

    }
}
