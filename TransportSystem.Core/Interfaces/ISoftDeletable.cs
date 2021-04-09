using System;
using System.Collections.Generic;
using System.Text;

namespace TransportSystem.Core.Interfaces
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
