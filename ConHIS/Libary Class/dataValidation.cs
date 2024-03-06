using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConHIS
{
    public class DataValidation
    {
        private readonly ValidationContext context;
        private readonly List<ValidationResult> resultVal;
        private readonly bool valid;
        private string message;
        private readonly string fileName;
        private readonly System_logfile log = new System_logfile();

        public DataValidation(object intace)
        {
            context = new ValidationContext(intace);
            resultVal = new List<ValidationResult>();
            valid = Validator.TryValidateObject(intace, context, resultVal, true);
        }

        public DataValidation(object intace, string filename)
        {
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
                message = "ตรวจสอบฟิลด์ข้อมูลก่อนบันทึก \n";
                foreach (ValidationResult item in resultVal)
                {
                    message += i + " -> " + item.ErrorMessage + "\n";
                    i++;
                }
                log.Writelogfile("[" + fileName + "] : " + message, " ConHIS_Error_Validate");
            }
            return valid;
        }
    }
}