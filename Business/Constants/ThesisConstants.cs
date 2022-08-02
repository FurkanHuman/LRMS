using Business.Constants.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class ThesisConstants : BaseConstants
    {
        protected ThesisConstants() { }

        public const string ThesisDegreeRequired = "Thesis Degree is Required.";
        public const string CityIdRequired = "City Id is Required.";
        public const string DateTimeError = "Year null & blank or greater than the current year.";
        public const string LanguageIdRequired = "Language Id is Required.";
        public const string ThesisNumberRequired = "Thesis Number is Required.";
        public const string ApprovalStatusRequired = "Approval Status is Required.";
        public const string PermissionStatusRequired = "Permission Status is Required.";
    }
}
