using Business.Constants.Base;

namespace Business.Constants
{
    public class TechnicalPlaceholderConstants : BaseConstants
    {
        protected TechnicalPlaceholderConstants() { }

        public const string ISBNNumberEmpty = "ISBN data is empty.";
        public const string BarcodeNull = "Barcode is empty";
        public const string StockNumberEmpty = "Stock number not fetched.";
        public const string WhereMaterialEmpty = "material placeholder cannot be empty.";
        public const string StockNumberNotNull = "Stock number is not null.";
        public const string LibraryEmpty = "Library is empty.";
    }
}
