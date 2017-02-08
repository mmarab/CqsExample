using System.Collections.Generic;

namespace Mmarab.CqsExample.Api.Models
{
    public class ValidationResult
    {
        public static ValidationResult Ok = new ValidationResult("Ok");

        public ValidationResult()
        {

        }

        public ValidationResult(params string[] messages)
        {
            Messages = messages;
        }

        public IEnumerable<string> Messages { get; set; }
        
        public static ValidationResult Error(string message, params object[] args)
        {
            return new ValidationResult(string.Format(message, args));
        }
    }
}