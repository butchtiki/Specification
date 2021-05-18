using System;
using System.Collections.Generic;

namespace Specification
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderRequest newrequest = new OrderRequest()
            {
                SenderEmail = "christopher@gmail.com",
                SenderName = "Christopher Henry Davila",
                SenderContactNumber = "+639156420773",
                RecipientEmail = "Chris",
                RecipientName = "Chris",
                RecipientContactNumber = "+639156420773"
            };

            ValidEmailSpecification validEmailSpec;
            ValidNameSpecification validNameSpec;
            ValidContactNumberSpecification validContactNumber;
            ValidRequestSpecification validRequest;


            validEmailSpec = new ValidEmailSpecification();
            validNameSpec = new ValidNameSpecification();
            validContactNumber = new ValidContactNumberSpecification();
            validRequest = new ValidRequestSpecification();


            var errorList = new List<string>() as ICollection<string>;
            bool isValid = validEmailSpec.And(validNameSpec).And(validContactNumber)
                .And(validRequest).IsSatisfiedBy(newrequest, ref errorList);

            if (isValid)
            {
                Console.WriteLine("Valid Order Request Info");
            }
            else
            {
                Console.WriteLine("Invalid Order Request Info");
            }
            
        }
    }
}
