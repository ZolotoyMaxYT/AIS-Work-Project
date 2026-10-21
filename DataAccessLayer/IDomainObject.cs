using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IDomainObject
    {
        string Id { get; set; }
    }
}
