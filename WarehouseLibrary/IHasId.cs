﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface IHasId
    {
        public Guid Id
        {
            get { return Id; }
            private set { Id = value; }
        }
    }
}
