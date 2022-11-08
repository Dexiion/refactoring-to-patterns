namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;
        private readonly int? _mobileNumber;

        private ProductPackage(string internetLabel, int? telephoneNumber, string[] tvChannels, int? mobileNumber)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
            _mobileNumber = mobileNumber;
        }

        public bool HasInternet()
        {
            return _internetLabel != null;
        }


        public bool HasVOIP()
        {
            return _telephoneNumber != null;
        }

        public bool HasTv()
        {
            return _tvChannels != null;
        }

        public bool HasMobile()
        {
            return _mobileNumber != null;
        }

        public static ProductPackage CreateInternetVOIPAndTvPackage(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, tvChannels, null);
            return productPackage;
        }

        public static ProductPackage CreateInternetAndTvPackage(string internetLabel, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, null, tvChannels, null);
            return productPackage;
        }

        public static ProductPackage CreateInternetAndVoipPackage(string internetLabel, int telephoneNumber)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, null, null);
            return productPackage;
        }

        public static ProductPackage CreateInternetPackage(string internetLabel)
        {
            var productPackage = new ProductPackage(internetLabel, null, null, null);
            return productPackage;
        }

        public static ProductPackage CreateInternetAndMobilePackage(string internetLabel, int mobileNumber)
        {
            var productPackage = new ProductPackage(internetLabel, null, null, mobileNumber);
            return productPackage;
        }

        public static ProductPackage CreateInternetMobileAndTvPackage(string internetLabel, int mobileNumber, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, null, tvChannels, mobileNumber);
            return productPackage;
        }
    }
}