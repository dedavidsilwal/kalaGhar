using KalaGhar.Domain.Common;
using System;
using System.Collections.Generic;

namespace KalaGhar.Domain.ValueObjects
{
    public class CraftValueObject : ValueObject
    {
        public CraftValueObject()
        {
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
