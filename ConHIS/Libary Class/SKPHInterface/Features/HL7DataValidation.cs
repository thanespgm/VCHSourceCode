using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConHIS.Libary_Class.SKPHInterface.Features
{
    public class HL7DataValidation
    {
        private readonly ValidationContext context;
        private readonly List<ValidationResult> resultVal;
        private readonly bool valid;
        private string message;
        private readonly string fileName;
        private readonly System_logfile log;

        public HL7DataValidation(object intace, string filename)
        {
            log = new System_logfile();
            fileName = filename;
            context = new ValidationContext(intace);
            resultVal = new List<ValidationResult>();
            valid = Validator.TryValidateObject(intace, context, resultVal, true);
        }

        public bool Validate()
        {
            if (!valid)
            {
                int i = 1;
                foreach (ValidationResult item in resultVal)
                {
                    message += i + ") " + item.ErrorMessage + "\n";
                    i++;
                }
                log.LogPerFile(message, "[ "+fileName + " ] Error_HL7DataValidation");
            }
            return valid;
        }
    }
}
