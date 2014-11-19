using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProjectPerformer:BaseEntity

    {
        public virtual  Project Project{ set; get;}
        public virtual Performer Performer { set; get; }

    }
}
