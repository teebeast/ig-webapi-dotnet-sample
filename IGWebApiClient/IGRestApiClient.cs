using System;
using System.Net.Http;
using System.Threading.Tasks;
using dto.endpoint.auth.session.v2;
using dto.endpoint.auth.encryptionkey;
using dto.endpoint.browse;
using dto.endpoint.watchlists.retrieve;
using IGWebApiClient.Common;
using IGWebApiClient.Security;
using dto.endpoint.accountactivity.transaction;
using dto.endpoint.accountactivity.activity;
using dto.endpoint.marketdetails.v2;
using dto.endpoint.positions.create.otc.v1;
using dto.endpoint.positions.edit.v1;
using dto.endpoint.positions.close.v1;
using dto.endpoint.prices.v2;
using dto.endpoint.search;
using dto.endpoint.watchlists.manage.delete;
using dto.endpoint.watchlists.manage.create;
using dto.endpoint.watchlists.manage.edit;
using dto.endpoint.workingorders.create.v1;
using dto.endpoint.workingorders.edit.v1;
using dto.endpoint.workingorders.delete.v1;
using dto.endpoint.confirms;
using dto.endpoint.browse.sprintmarkets;
using dto.endpoint.clientsentiment;
using dto.endpoint.application.operation;
using System.Collections.Generic;
using dto.endpoint.accountswitch;
using dto.endpoint.accountbalance;

namespace IGWebApiClient
{
    public partial class IgRestApiClient
	{
        private PropertyEventDispatcher _eventDispatcher;
        private ConversationContext _conversationContext;

        private readonly IgRestService _igRestService;

        public IgRestApiClient(string environment, PropertyEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
            _igRestService = new IgRestService(eventDispatcher, environment);
        }


        protected EncryptionKeyResponse EncryptionKeyResponse { get; set; }

        public ConversationContext GetConversationContext()
        {
            return _conversationContext;
        }

        public async Task<IgResponse<AuthenticationResponse>> SecureAuthenticate(AuthenticationRequest ar, string apiKey)
        {
            _conversationContext = new ConversationContext(null, null, apiKey);
            var encryptedPassword = await SecurePassword(ar.password);

            ar.encryptedPassword = encryptedPassword != ar.password;
            ar.password = encryptedPassword;
            return await Authenticate(ar);
        }

        private async Task<string> SecurePassword(string rawPassword)
        {
            var encryptedPassword = rawPassword;

            //Try encrypting password. If we can encrypt it, do so...                                                                            
            var secureResponse = await FetchEncryptionKey();

            EncryptionKeyResponse = new EncryptionKeyResponse();
            EncryptionKeyResponse = secureResponse.Response;

            if (EncryptionKeyResponse != null)
            {
                // get a public key to ENCRYPT...
                var rsa = new Rsa(Convert.FromBase64String(EncryptionKeyResponse.encryptionKey), true);

                var encryptedBytes = rsa.RsaEncrypt($"{rawPassword}|{EncryptionKeyResponse.timeStamp}");
                encryptedPassword = Convert.ToBase64String(encryptedBytes);
            }
            return encryptedPassword;
        }

		///<Summary>
		///Creates a trading session, obtaining session tokens for subsequent API access.
		///<p>
		///   Please note that region-specific <a href="/loginrestrictions">login restrictions</a> may apply.
		///</p>
		///@param authenticationRequest Client login credentials
		///@return Client summary account information
		///</Summary>

		public async Task<IgResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest authenticationRequest) 
		{
			return await _igRestService.RestfulService<AuthenticationResponse>("/gateway/deal/session", HttpMethod.Post, "2", _conversationContext, authenticationRequest);
		}


		///<Summary>
		///Creates a trading session, obtaining session tokens for subsequent API access
		///@return the encryption key to be used to encode the credentials
		///</Summary>

		public async Task<IgResponse<EncryptionKeyResponse>> FetchEncryptionKey() 
		{
			return await _igRestService.RestfulService<EncryptionKeyResponse>("/gateway/deal/session/encryptionKey", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Log out of the current session
		///</Summary>

		public async void Logout() 
		{
			await _igRestService.RestfulService("/gateway/deal/session", HttpMethod.Delete, "1", _conversationContext);
		}

		///<Summary>
		///Returns all top-level nodes (market categories) in the market navigation hierarchy.
		///</Summary>

		public async Task<IgResponse<BrowseMarketsResponse>> BrowseRoot() 
		{
			return await _igRestService.RestfulService<BrowseMarketsResponse>("/gateway/deal/marketnavigation", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all sub-nodes of the given node in the market navigation hierarchy
		///@return the children of the selected node
		///@throws BrowseMarketsException
		///@pathParam nodeId the identifier of the node to browse
		///</Summary>

		public async Task<IgResponse<BrowseMarketsResponse>> Browse(string nodeId) 
		{
			return await _igRestService.RestfulService<BrowseMarketsResponse>("/gateway/deal/marketnavigation/" + nodeId, HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all open positions for the active account
		///</Summary>

		public async Task<IgResponse<dto.endpoint.positions.get.otc.v2.PositionsResponse>> GetOtcOpenPositionsV2() 
		{
			return await _igRestService.RestfulService<dto.endpoint.positions.get.otc.v2.PositionsResponse>("/gateway/deal/positions", HttpMethod.Get, "2", _conversationContext);
		}

		///<Summary>
		///Returns all watchlists belonging to the active account
		///</Summary>

		public async Task<IgResponse<ListOfWatchlistsResponse>> ListOfWatchlists() 
		{
			return await _igRestService.RestfulService<ListOfWatchlistsResponse>("/gateway/deal/watchlists", HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns the given watchlists markets
		///@pathParam watchlistId Watchlist id
		///</Summary>

		public async Task<IgResponse<WatchlistInstrumentsResponse>> InstrumentsForWatchlist(string watchlistId) 
		{
			return await _igRestService.RestfulService<WatchlistInstrumentsResponse>("/gateway/deal/watchlists/" + watchlistId, HttpMethod.Get, "1", _conversationContext);
		}

		///<Summary>
		///Returns all open working orders for the active account
		///</Summary>

		public async Task<IgResponse<dto.endpoint.workingorders.get.v2.WorkingOrdersResponse>> WorkingOrdersV2() 
		{
			return await _igRestService.RestfulService<dto.endpoint.workingorders.get.v2.WorkingOrdersResponse>("/gateway/deal/workingorders", HttpMethod.Get, "2", _conversationContext);
		}



        ///<Summary>
        ///Returns the account activity history for the last specified period
        ///@pathParam lastPeriod Interval in milliseconds
        ///</Summary>

        public async Task<IgResponse<ActivityHistoryResponse>> LastActivityPeriod(string lastPeriod)
        {
            return await _igRestService.RestfulService<ActivityHistoryResponse>("/gateway/deal/history/activity/" + lastPeriod, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns the account activity history for the given date range
        ///@pathParam fromDateStr Start date in dd-mm-yyyy format
        ///@pathParam toDateStr End date in dd-mm-yyyy format
        ///</Summary>

        public async Task<IgResponse<ActivityHistoryResponse>> LastActivityTimeRange(string fromDate, string toDate)
        {
            return await _igRestService.RestfulService<ActivityHistoryResponse>("/gateway/deal/history/activity/" + fromDate + "/" + toDate, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns the transaction history for the specified transaction type and period
        ///@pathParam transactionType Transaction type (( ALL, ALL_DEAL, DEPOSIT, WITHDRAWAL ) )
        ///@pathParam lastPeriod Interval in milliseconds
        ///</Summary>

        public async Task<IgResponse<TransactionHistoryResponse>> LastTransactionPeriod(string transactionType, string lastPeriod)
        {
            return await _igRestService.RestfulService<TransactionHistoryResponse>("/gateway/deal/history/transactions/" + transactionType + "/" + lastPeriod, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns the transaction history for the specified transaction type and given date range
        ///@pathParam transactionType Transaction type (( ALL, ALL_DEAL, DEPOSIT, WITHDRAWAL ) )
        ///@pathParam fromDate Start date in dd-mm-yyyy format
        ///@pathParam toDate End date in dd-mm-yyyy format
        ///</Summary>

        public async Task<IgResponse<TransactionHistoryResponse>> LastTransactionTimeRange(string transactionType, string fromDate, string toDate)
        {
            return await _igRestService.RestfulService<TransactionHistoryResponse>("/gateway/deal/history/transactions/" + transactionType + "/" + fromDate + "/" + toDate, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns a list of accounts belonging to the logged-in client
        ///</Summary>

        public async Task<IgResponse<AccountDetailsResponse>> AccountBalance()
        {
            return await _igRestService.RestfulService<AccountDetailsResponse>("/gateway/deal/accounts", HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Switches active accounts, optionally setting the default account
        ///@param accountSwitchRequest Account switch request
        ///</Summary>

        public async Task<IgResponse<AccountSwitchResponse>> AccountSwitch(AccountSwitchRequest accountSwitchRequest)
        {
            return await _igRestService.RestfulService<AccountSwitchResponse>("/gateway/deal/session", HttpMethod.Put, "1", _conversationContext, accountSwitchRequest);
        }


        ///<Summary>
        ///Alters the details of a given user application
        ///@param updateApplicationRequest application update request
        ///</Summary>

        public async Task<IgResponse<Application>> Update(UpdateApplicationRequest updateApplicationRequest)
        {
            return await _igRestService.RestfulService<Application>("/gateway/deal/operations/application", HttpMethod.Put, "1", _conversationContext, updateApplicationRequest);
        }

        ///<Summary>
        ///Disables the current application key from processing further requests.  Disabled keys may be reenabled via the My Account section on our web dealing platform.
        ///</Summary>

        public async Task<IgResponse<Application>> DisableApplication()
        {
            return await _igRestService.RestfulService<Application>("/gateway/deal/operations/application/disable", HttpMethod.Put, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns a list of client-owned applications
        ///</Summary>

        public async Task<IgResponse<List<Application>>> FindClientApplications()
        {
            return await _igRestService.RestfulService<List<Application>>("/gateway/deal/operations/application", HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Creates a trading session, obtaining session tokens for subsequent API access
        ///@param authenticationRequest Client login credentials
        ///@return Client summary account information
        ///</Summary>

        private async Task<IgResponse<dto.endpoint.auth.session.AuthenticationResponse>> Authenticate(dto.endpoint.auth.session.AuthenticationRequest authenticationRequest)
        {
            return await _igRestService.RestfulService<dto.endpoint.auth.session.AuthenticationResponse>("/gateway/deal/session", HttpMethod.Post, "1", _conversationContext, authenticationRequest);
        }

        ///<Summary>
        ///</Summary>

        public async Task<IgResponse<SprintMarketsSearchResponse>> FindAll()
        {
            return await _igRestService.RestfulService<SprintMarketsSearchResponse>("/gateway/deal/sprintmarkets", HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns the client sentiment for the given instrument's market
        ///@pathParam marketId Market identifier
        ///</Summary>

        public async Task<IgResponse<ClientSentiment>> GetClientSentiment(string marketId)
        {
            return await _igRestService.RestfulService<ClientSentiment>("/gateway/deal/clientsentiment/" + marketId, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns a list of related (what others have traded) client sentiment for the given instrument's market
        ///@pathParam marketId Market identifier
        ///</Summary>

        public async Task<IgResponse<ClientSentimentList>> GetRelatedClientSentiment(string marketId)
        {
            return await _igRestService.RestfulService<ClientSentimentList>("/gateway/deal/clientsentiment/related/" + marketId, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns a deal confirmation for the given deal reference
        ///@pathParam dealReference Deal reference
        ///</Summary>

        public async Task<IgResponse<ConfirmsResponse>> RetrieveConfirm(string dealReference)
        {
            return await _igRestService.RestfulService<ConfirmsResponse>("/gateway/deal/confirms/" + dealReference, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns the details of the given market
        ///@pathParam epic The epic of the market to be retrieved
        ///</Summary>

        public async Task<IgResponse<dto.endpoint.marketdetails.v1.MarketDetailsResponse>> MarketDetails(string epic)
        {
            return await _igRestService.RestfulService<dto.endpoint.marketdetails.v1.MarketDetailsResponse>("/gateway/deal/markets/" + epic, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns the details of the given market
        ///@pathParam epic The epic of the market to be retrieved
        ///</Summary>

        public async Task<IgResponse<MarketDetailsResponse>> MarketDetailsV2(string epic)
        {
            return await _igRestService.RestfulService<MarketDetailsResponse>("/gateway/deal/markets/" + epic, HttpMethod.Get, "2", _conversationContext);
        }

        ///<Summary>
        ///Returns the details of the given markets.
        ///@pathParam epics The epics of the market to be retrieved, separated by a comma. Max number of epics is limited to 50.
        ///</Summary>

        public async Task<IgResponse<MarketDetailsListResponse>> MarketDetailsMulti(string epicsList)
        {
            return await _igRestService.RestfulService<MarketDetailsListResponse>("/gateway/deal/markets?epics=" + epicsList, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Creates an OTC position
        ///@param createPositionRequest the request for creating a position
        ///@return OTC create position response
        ///</Summary>

        public async Task<IgResponse<CreatePositionResponse>> CreatePositionV1(CreatePositionRequest createPositionRequest)
        {
            return await _igRestService.RestfulService<CreatePositionResponse>("/gateway/deal/positions/otc", HttpMethod.Post, "1", _conversationContext, createPositionRequest);
        }

        ///<Summary>
        ///Creates an OTC position
        ///@param createPositionRequest the request for creating a position
        ///@return OTC create position response
        ///</Summary>

        public async Task<IgResponse<CreatePositionResponse>> CreatePositionV2(dto.endpoint.positions.create.otc.v2.CreatePositionRequest createPositionRequest)
        {
            return await _igRestService.RestfulService<CreatePositionResponse>("/gateway/deal/positions/otc", HttpMethod.Post, "2", _conversationContext, createPositionRequest);
        }

        ///<Summary>
        ///Updates an OTC position
        ///@pathParam dealId Deal reference identifier
        ///@param editPositionRequest the request for updating a position
        ///@return OTC edit position response
        ///</Summary>

        public async Task<IgResponse<EditPositionResponse>> EditPositionV1(string dealId, EditPositionRequest editPositionRequest)
        {
            return await _igRestService.RestfulService<EditPositionResponse>("/gateway/deal/positions/otc/" + dealId, HttpMethod.Put, "1", _conversationContext, editPositionRequest);
        }

        ///<Summary>
        ///Updates an OTC position
        ///@pathParam dealId Deal reference identifier
        ///@param editPositionRequest the request for updating a position
        ///@return OTC edit position response
        ///</Summary>

        public async Task<IgResponse<EditPositionResponse>> EditPositionV2(string dealId, dto.endpoint.positions.edit.v2.EditPositionRequest editPositionRequest)
        {
            return await _igRestService.RestfulService<EditPositionResponse>("/gateway/deal/positions/otc/" + dealId, HttpMethod.Put, "2", _conversationContext, editPositionRequest);
        }

        ///<Summary>
        ///Closes one or more OTC positions
        ///@param closePositionRequest the request for closing one or more positions
        ///@return OTC close position response
        ///</Summary>

        public async Task<IgResponse<ClosePositionResponse>> ClosePosition(ClosePositionRequest closePositionRequest)
        {
            return await _igRestService.RestfulService<ClosePositionResponse>("/gateway/deal/positions/otc", HttpMethod.Delete, "1", _conversationContext, closePositionRequest);
        }

        ///<Summary>
        ///Returns all open positions for the active account
        ///</Summary>

        public async Task<IgResponse<dto.endpoint.positions.get.otc.v1.PositionsResponse>> GetOtcOpenPositionsV1()
        {
            return await _igRestService.RestfulService<dto.endpoint.positions.get.otc.v1.PositionsResponse>("/gateway/deal/positions", HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns an open position for the active account by deal identifier
        ///@pathParam dealId Deal reference identifier
        ///</Summary>

        public async Task<IgResponse<dto.endpoint.positions.get.otc.v1.OpenPosition>> GetOtcOpenPositionByDealIdV1(string dealId)
        {
            return await _igRestService.RestfulService<dto.endpoint.positions.get.otc.v1.OpenPosition>("/gateway/deal/positions/" + dealId, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns an open position for the active account by deal identifier
        ///@pathParam dealId Deal reference identifier
        ///</Summary>

        public async Task<IgResponse<dto.endpoint.positions.get.otc.v2.OpenPosition>> GetOtcOpenPositionByDealIdV2(string dealId)
        {
            return await _igRestService.RestfulService<dto.endpoint.positions.get.otc.v2.OpenPosition>("/gateway/deal/positions/" + dealId, HttpMethod.Get, "2", _conversationContext);
        }


        ///<Summary>
        ///Returns a list of historical prices for the given epic, resolution and date range.
        ///@pathParam epic Instrument epic
        ///@pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30, HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
        ///@requestParam startdate Start date (yyyy:MM:dd-HH:mm:ss)
        ///@requestParam enddate End date (yyyy:MM:dd-HH:mm:ss). Must be later then the start date.
        ///</Summary>

        public async Task<IgResponse<PriceList>> PriceSearchByDate(string epic, string resolution, string startdate, string enddate)
        {
            return await _igRestService.RestfulService<PriceList>("/gateway/deal/prices/" + epic + "/" + resolution + "?startdate=" + startdate + "&enddate=" + enddate, HttpMethod.Get, "1", _conversationContext);
        }

        ///<Summary>
        ///Returns a list of historical prices for the given epic, resolution and number of data points
        ///@pathParam epic Instrument epic
        ///@pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30, HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
        ///@pathParam numPoints Number of data points required
        ///</Summary>

        public async Task<IgResponse<PriceList>> PriceSearchByNum(string epic, string resolution, string numPoints)
        {
            return await _igRestService.RestfulService<PriceList>("/gateway/deal/prices/" + epic + "/" + resolution + "/" + numPoints, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Returns a list of historical prices for the given epic, resolution and date range.
        ///@pathParam epic Instrument epic
        ///@pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30, HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
        ///@pathParam startDate Start date (yyyy-MM-dd HH:mm:ss)
        ///@pathParam endDate End date (yyyy-MM-dd HH:mm:ss). Must be later then the start date.
        ///</Summary>

        public async Task<IgResponse<PriceList>> PriceSearchByDateV2(string epic, string resolution, string startDate, string endDate)
        {
            return await _igRestService.RestfulService<PriceList>("/gateway/deal/prices/" + epic + "/" + resolution + "/" + startDate + "/" + endDate, HttpMethod.Get, "2", _conversationContext);
        }

        ///<Summary>
        ///Returns a list of historical prices for the given epic, resolution and number of data points
        ///@pathParam epic Instrument epic
        ///@pathParam resolution Price resolution (MINUTE, MINUTE_2, MINUTE_3, MINUTE_5, MINUTE_10, MINUTE_15, MINUTE_30, HOUR, HOUR_2, HOUR_3, HOUR_4, DAY, WEEK, MONTH)
        ///@pathParam numPoints Number of data points required
        ///</Summary>

        public async Task<IgResponse<PriceList>> PriceSearchByNumV2(string epic, string resolution, string numPoints)
        {
            return await _igRestService.RestfulService<PriceList>("/gateway/deal/prices/" + epic + "/" + resolution + "/" + numPoints, HttpMethod.Get, "2", _conversationContext);
        }


        ///<Summary>
        ///Returns all markets matching the search term
        ///@return market search result
        ///@throws SearchMarketsException
        ///@requestParam searchTerm The term to be used in the search
        ///</Summary>

        public async Task<IgResponse<SearchMarketsResponse>> SearchMarket(string searchTerm)
        {
            return await _igRestService.RestfulService<SearchMarketsResponse>("/gateway/deal/markets?searchTerm=" + searchTerm, HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Deletes a watchlist
        ///@pathParam watchlistId Watchlist id
        ///</Summary>

        public async Task<IgResponse<DeleteWatchlistResponse>> DeleteWatchlist(string watchlistId)
        {
            return await _igRestService.RestfulService<DeleteWatchlistResponse>("/gateway/deal/watchlists/" + watchlistId, HttpMethod.Delete, "1", _conversationContext);
        }

        ///<Summary>
        ///Creates a watchlist
        ///@param createWatchlistRequest Watchlist create request
        ///</Summary>

        public async Task<IgResponse<CreateWatchlistResponse>> CreateWatchlist(CreateWatchlistRequest createWatchlistRequest)
        {
            return await _igRestService.RestfulService<CreateWatchlistResponse>("/gateway/deal/watchlists", HttpMethod.Post, "1", _conversationContext, createWatchlistRequest);
        }

        ///<Summary>
        ///Adds a market to a watchlist
        ///@pathParam watchlistId Watchlist id
        ///@param addInstrumentToWatchlistRequest Add market to watchlist request
        ///</Summary>

        public async Task<IgResponse<AddInstrumentToWatchlistResponse>> AddInstrumentToWatchlist(string watchlistId, AddInstrumentToWatchlistRequest addInstrumentToWatchlistRequest)
        {
            return await _igRestService.RestfulService<AddInstrumentToWatchlistResponse>("/gateway/deal/watchlists/" + watchlistId, HttpMethod.Put, "1", _conversationContext, addInstrumentToWatchlistRequest);
        }

        ///<Summary>
        ///Remove a market from a watchlist
        ///@pathParam watchlistId Watchlist id
        ///@pathParam epic Market epic
        ///</Summary>

        public async Task<IgResponse<RemoveInstrumentFromWatchlistResponse>> RemoveInstrumentFromWatchlist(string watchlistId, string epic)
        {
            return await _igRestService.RestfulService<RemoveInstrumentFromWatchlistResponse>("/gateway/deal/watchlists/" + watchlistId + "/" + epic, HttpMethod.Delete, "1", _conversationContext);
        }



        ///<Summary>
        ///Returns all open working orders for the active account
        ///</Summary>

        public async Task<IgResponse<dto.endpoint.workingorders.get.v1.WorkingOrdersResponse>> WorkingOrdersV1()
        {
            return await _igRestService.RestfulService<dto.endpoint.workingorders.get.v1.WorkingOrdersResponse>("/gateway/deal/workingorders", HttpMethod.Get, "1", _conversationContext);
        }


        ///<Summary>
        ///Creates an OTC working order
        ///@deprecated Use version 2 of the service instead
        ///@param createWorkingOrderRequest Create working order request data
        ///</Summary>

        public async Task<IgResponse<CreateWorkingOrderResponse>> CreateWorkingOrderV1(CreateWorkingOrderRequest createWorkingOrderRequest)
        {
            return await _igRestService.RestfulService<CreateWorkingOrderResponse>("/gateway/deal/workingorders/otc", HttpMethod.Post, "1", _conversationContext, createWorkingOrderRequest);
        }

        ///<Summary>
        ///Creates an OTC working order
        ///@param createWorkingOrderRequest Create working order request data
        ///</Summary>

        public async Task<IgResponse<CreateWorkingOrderResponse>> CreateWorkingOrderV2(dto.endpoint.workingorders.create.v2.CreateWorkingOrderRequest createWorkingOrderRequest)
        {
            return await _igRestService.RestfulService<CreateWorkingOrderResponse>("/gateway/deal/workingorders/otc", HttpMethod.Post, "2", _conversationContext, createWorkingOrderRequest);
        }

        ///<Summary>
        ///Updates an OTC working order
        ///@deprecated Use version 2 of the service instead
        ///@pathParam dealId Deal identifier
        ///@param editWorkingOrderRequest Update working order request data
        ///</Summary>

        public async Task<IgResponse<EditWorkingOrderResponse>> EditWorkingOrderV1(string dealId, EditWorkingOrderRequest editWorkingOrderRequest)
        {
            return await _igRestService.RestfulService<EditWorkingOrderResponse>("/gateway/deal/workingorders/otc/" + dealId, HttpMethod.Put, "1", _conversationContext, editWorkingOrderRequest);
        }

        ///<Summary>
        ///Updates an OTC working order
        ///@pathParam dealId Deal identifier
        ///@param editWorkingOrderRequest Update working order request data
        ///</Summary>

        public async Task<IgResponse<EditWorkingOrderResponse>> EditWorkingOrderV2(string dealId, dto.endpoint.workingorders.edit.v2.EditWorkingOrderRequest editWorkingOrderRequest)
        {
            return await _igRestService.RestfulService<EditWorkingOrderResponse>("/gateway/deal/workingorders/otc/" + dealId, HttpMethod.Put, "2", _conversationContext, editWorkingOrderRequest);
        }

        ///<Summary>
        ///Deletes an OTC working order
        ///@pathParam dealId Deal identifier
        ///@param deleteWorkingOrderRequest Delete working order request data
        ///</Summary>

        public async Task<IgResponse<DeleteWorkingOrderResponse>> DeleteWorkingOrder(string dealId, DeleteWorkingOrderRequest deleteWorkingOrderRequest)
        {
            return await _igRestService.RestfulService<DeleteWorkingOrderResponse>("/gateway/deal/workingorders/otc/" + dealId, HttpMethod.Delete, "1", _conversationContext, deleteWorkingOrderRequest);
        }

    }
}
