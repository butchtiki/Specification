using System;
using System.Collections.Generic;

namespace Specification
{
    public class ValidRequestSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref ICollection<string> errors)
        {
            if (data.RecipientEmail != null && data.RecipientEmail.Trim(' ').Length > 0 &&
                data.RecipientName != null && data.RecipientName.Trim(' ').Length > 0 &&
                data.RecipientContactNumber != null && data.RecipientContactNumber.Trim(' ').Length > 0)
            {
                return true;

            }
            return false;
        }
    }
}
