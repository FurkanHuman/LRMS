using Business.Constants.Base;

namespace Business.Constants
{
    public class MagazineConstants : BaseConstants
    {
        protected MagazineConstants()
        {

        }

        public enum MagazineTypes // todo research magazine type , current example
        {
            Other,
            Kids,
            bla,
            blaa,
            Blaaa
        }

        public const string TypeNull = "Magazine Type is null.";
        public const string VolumeNull = "Magazine volume is null.";
    }
}
