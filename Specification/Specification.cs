using System;
using System.Collections.Generic;

namespace Specification
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T data, ref ICollection<string> errors);

        public Specification<T> And(Specification<T> spec)
        {
            return new AndSpecification<T>(this, spec);
        }
    }
}