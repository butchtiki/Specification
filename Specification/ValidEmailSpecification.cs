using System;
using System.Collections.Generic;
using System.Net.Mail;
namespace Specification
{
    public class ValidEmailSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref ICollection<string> errors)
        {
            try
            {
                if (data.SenderEmail != null)
                {
                    var addr = new MailAddress(data.SenderEmail);
                    bool isValid = addr.Address == data.SenderEmail;
                    if (isValid)
                    {
                        //check if theres dot after @*
                        if (data.SenderEmail.IndexOf('.') > (data.SenderEmail.IndexOf('@') + 1))
                        {
                            return true;
                        }
                    }
                }
                
                return false;
            }
            catch
            {
                return false;
            }
        }


    }
}
