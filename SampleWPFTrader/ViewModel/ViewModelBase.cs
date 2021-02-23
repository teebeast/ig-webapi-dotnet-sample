using IGWebApiClient;
using SampleWPFTrader.Common;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace SampleWPFTrader.ViewModel
{
    public abstract class ViewModelBase : PropertyChanged
    {
		public static IgRestApiClient IgRestApiClient;
		public static IGStreamingApiClient IgStreamApiClient;

		public enum TradeSubscriptionType
		{
			Opu = 0,
			Wou = 1,
			Confirm = 2
		}
		
        public static string CurrentAccountId;
      
        public void InitialiseViewModel()
        {
            var igWebApiConnectionConfig = ConfigurationManager.GetSection("IgWebApiConnection") as NameValueCollection;
            var env = igWebApiConnectionConfig["environment"];

            var smartDispatcher = (SmartDispatcher) SmartDispatcher.GetInstance();
            smartDispatcher.SetViewModel(ApplicationViewModel.getInstance());

            IgRestApiClient = new IgRestApiClient(env, smartDispatcher);           
            IgStreamApiClient = new IGStreamingApiClient();            
        }

        public static bool LoggedIn { get; set; }             
  
        public string ConvertMarketStatusToString(dto.endpoint.type.MarketStatus marketStatus)
        {
            string strMarketStatus;

            switch (marketStatus)
            {
                case dto.endpoint.type.MarketStatus.CLOSED:
                    strMarketStatus = "Closed";
                    break;
                case dto.endpoint.type.MarketStatus.EDITS_ONLY:
                    strMarketStatus = "Edits Only";
                    break;
                case dto.endpoint.type.MarketStatus.OFFLINE:
                    strMarketStatus = "Offline";
                    break;
                case dto.endpoint.type.MarketStatus.ON_AUCTION:
                    strMarketStatus = "On Auction";
                    break;
                case dto.endpoint.type.MarketStatus.ON_AUCTION_NO_EDITS:
                    strMarketStatus = "On Auction no edits";
                    break;
                case dto.endpoint.type.MarketStatus.SUSPENDED:
                    strMarketStatus = "Suspended";
                    break;
                default:
                    strMarketStatus = "Closed";
                    break;
            }
            return strMarketStatus;
        }

        // Add a message to the status textbox
        public void AddStatusMessage(string message)
        {
            UpdateDebugMessage(message);
        }

        private string _applicationDebugData;

        public string ApplicationDebugData
        {
            get => _applicationDebugData;
            set
            {
                if (_applicationDebugData != value)
                {
                    _applicationDebugData = value;
                    RaisePropertyChanged("ApplicationDebugData");
                }
            }
        }
        public void UpdateDebugMessage(string message)
        {
            if (ApplicationDebugData != message)
            {
                ApplicationDebugData = DateTime.UtcNow + ": " + message + Environment.NewLine + ApplicationDebugData;
            }
        }

    }
}
