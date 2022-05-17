using Business.Constants.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class CityConstants:BaseConstants
    {
        public const string CityExist= "City already exist.";
        public const string CityNameNull="City name is null";
        public const string CityAddedNotDeleted = "It cannot be deleted as a shadow when adding a city. Don't try :)";
        public const string CityIdExist = "City already exist.";
    }
}
