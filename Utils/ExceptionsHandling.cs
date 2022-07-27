using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FluentValidation;
using FluentValidation.Results;

namespace RestChallenge.Utils
{
    public static class ExceptionsHandling 
    {


        public static List<string> getValidationErrorMessages(ValidationException ex)
        {
                List<string> messages = new List<string>();

                foreach (ValidationFailure failure in ex.Errors)
                {
                    messages.Add(failure.ErrorMessage);
                }
                return messages;
        }

        public static string getSqlErrorMessages(SqlException ex)
        {
            string errorMessage;
               if(ex.HResult == -2146232060)
                {
                  errorMessage = ex.Message.Split("\r")[0];        
                }else
                {
                    errorMessage = ex.Message;
                }

                return errorMessage;
        }
        public static string getInvalidOperationError(InvalidOperationException ex)
        {
            return ex.Message;
        }
    }
}