using System;
using System.Collections.Generic;
namespace Specification
{
    public class ValidContactNumberSpecification: Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref ICollection<string> errors)
        {
            if ((data.SenderContactNumber != null) &&
                (data.SenderContactNumber.Substring(0,4) == "+639") &&
                (data.SenderContactNumber.Length == 13))
            {
                return true;
            }
            return false;
        }

    }
}
