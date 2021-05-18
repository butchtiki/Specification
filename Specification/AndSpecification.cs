using System;
using System.Collections.Generic;

namespace Specification
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T data, ref ICollection<string> errors)
        {
            var result = this.left.IsSatisfiedBy(data, ref errors) && this.right.IsSatisfiedBy(data, ref errors);
            return result;
        }
    }
}
