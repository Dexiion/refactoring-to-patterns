namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;

        private ProductPackage(string internetLabel, int? telephoneNumber, string[] tvChannels)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
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

        public static ProductPackage CreateInternetVOIPAndTvPackage(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, tvChannels);
            return productPackage;
        }

        public static ProductPackage CreateInternetAndTvPackage(string internetLabel, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, null, tvChannels);
            return productPackage;
        }

        public static ProductPackage CreateInternetAndVoipPackage(string internetLabel, int telephoneNumber)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, null);
            return productPackage;
        }

        public static ProductPackage CreateInternetPackage(string internetLabel)
        {
            var productPackage = new ProductPackage(internetLabel, null, null);
            return productPackage;
        }
    }
}