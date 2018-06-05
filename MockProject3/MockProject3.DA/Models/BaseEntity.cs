using System;
using System.Collections.Generic;
using System.Text;

namespace MockProject3.DA.Models
{
    public abstract class BaseEntity
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
