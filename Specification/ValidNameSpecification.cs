using System;
using System.Collections.Generic;
namespace Specification
{
    public class ValidNameSpecification: Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref ICollection<string> errors)
        {
            if (data.SenderName != null && data.SenderName != "")
            {
                return true;
            }
            return false;

        }


    }
}
