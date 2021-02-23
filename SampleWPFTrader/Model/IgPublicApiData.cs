﻿using System;
using SampleWPFTrader.Common;

namespace SampleWPFTrader.Model
{
    public class IgPublicApiData
	{
        public class ClientSentimentModel : PropertyChanged
        {
			private decimal? _clientShort;
			public decimal? ClientShort
			{
				get => _clientShort;
                set
				{
					if (_clientShort != value)
					{
						_clientShort = value;
                        RaisePropertyChanged("ClientShort");
					}
				}
			}

			private decimal? _clientLong;
			public decimal? ClientLong
			{
				get => _clientLong;
                set
				{
					if (_clientLong != value)
					{
						_clientLong = value;
						RaisePropertyChanged("ClientLong");
					}
				}
			}

			private string _epic;
			public string Epic
			{
				get => _epic;
                set
				{
					if (_epic != value && value != null)
					{
						_epic = value;
						RaisePropertyChanged("Epic");
					}
				}
			}
		}

		public class TradeSubscriptionModel : PropertyChanged
		{
			private string _tradeType;
			public string TradeType
			{
				get => _tradeType;
                set
				{
					if (_tradeType != value)
					{
						_tradeType = value;
						RaisePropertyChanged("TradeType");
					}
				}
			}

			private string _itemName;
			public string ItemName
			{
				get => _itemName;
                set
				{
					if (_itemName != value)
					{
						_itemName = value;
						RaisePropertyChanged("ItemName");
					}
				}
			}

			private string _direction;
			public string Direction
			{
				get => _direction;
                set
				{
					if (_direction != value)
					{
						_direction = value;
						RaisePropertyChanged("Direction");
					}
				}
			}
			private string _limitlevel;
			public string Limitlevel
			{
				get => _limitlevel;
                set
				{
					if (_limitlevel != value)
					{
						_limitlevel = value;
						RaisePropertyChanged("Limitlevel");
					}
				}
			}
			private string _dealId;
			public string DealId
			{
				get => _dealId;
                set
				{
					if (_dealId != value)
					{
						_dealId = value;
						RaisePropertyChanged("DealId");
					}
				}
			}
			private string _affectedDealId;
			public string AffectedDealId
			{
				get => _affectedDealId;
                set
				{
					if (_affectedDealId != value)
					{
						_affectedDealId = value;
						RaisePropertyChanged("AffectedDealId");
					}
				}
			}
			private string _stopLevel;
			public string StopLevel
			{
				get => _stopLevel;
                set
				{
					if (_stopLevel != value)
					{
						_stopLevel = value;
						RaisePropertyChanged("StopLevel");
					}
				}
			}

			private string _expiry;
			public string Expiry
			{
				get => _expiry;
                set
				{
					if (_expiry != value)
					{
						_expiry = value;
						RaisePropertyChanged("Expiry");
					}
				}
			}
			private string _size;
			public string Size
			{
				get => _size;
                set
				{
					if (_size != value)
					{
						_size = value;
						RaisePropertyChanged("Size");
					}
				}
			}
			private string _status;
			public string Status
			{
				get => _status;
                set
				{
					if (_status != value)
					{
						_status = value;
						RaisePropertyChanged("Status");
					}
				}
			}
			private string _epic;
			public string Epic
			{
				get => _epic;
                set
				{
					if (_epic != value)
					{
						_epic = value;
						RaisePropertyChanged("Epic");
					}
				}
			}
			private string _level;
			public string Level
			{
				get => _level;
                set
				{
					if (_level != value)
					{
						_level = value;
						RaisePropertyChanged("Level");
					}
				}
			}
			private bool? _guaranteedStop;
			public bool? GuaranteedStop
			{
				get => _guaranteedStop;
                set
				{
					if (_guaranteedStop != value)
					{
						_guaranteedStop = value;
						RaisePropertyChanged("GuaranteedStop");
					}
				}
			}
			private string _dealReference;
			public string DealReference
			{
				get => _dealReference;
                set
				{
					if (_dealReference != value)
					{
						_dealReference = value;
						RaisePropertyChanged("DealReference");
					}
				}
			}
			private string _dealStatus;
			public string DealStatus
			{
				get => _dealStatus;
                set
				{
					if (_dealStatus != value)
					{
						_dealStatus = value;
						RaisePropertyChanged("DealStatus");
					}
				}
			}

		}

		public class AffectedDealModel : PropertyChanged
		{
			private string _affectedDealStatus;
			public string AffectedDealStatus
			{
				get => _affectedDealStatus;
                set
				{
					if (_affectedDealStatus != value)
					{
						_affectedDealStatus = value;
						RaisePropertyChanged("AffectedDealStatus");
					}
				}
			}

			private string _affectedDealId;
			public string AffectedDealId
			{
				get => _affectedDealId;
                set
				{
					if (_affectedDealId != value)
					{
						_affectedDealId = value;
						RaisePropertyChanged("AffectedDealId");
					}
				}
			}
		}


		public class AccountModel : PropertyChanged
		{
			private string _accountId;
			public string AccountId
			{
				get => _accountId;
                set
				{
					if (_accountId != value)
					{
						_accountId = value;
						RaisePropertyChanged("AccountId");
					}
				}
			}

			private string _accountType;
			public string AccountType
			{
				get => _accountType;
                set
				{
					if (_accountType != value)
					{
						_accountType = value;
						RaisePropertyChanged("AccountType");
					}
				}
			}

			private string _accountName;
			public string AccountName
			{
				get => _accountName;
                set
				{
					if (_accountName != value)
					{
						_accountName = value;
						RaisePropertyChanged("AccountName");
					}
				}
			}
			private string _clientId;
			public string ClientId
			{
				get => _clientId;
                set
				{
					if (_clientId != value)
					{
						_clientId = value;
						RaisePropertyChanged("ClientId");
					}
				}
			}

			private string _userName;
			public string UserName
			{
				get => _userName;
                set
				{
					if (_userName != value)
					{
						_userName = value;
						RaisePropertyChanged("UserName");
					}
				}
			}

			private string _lsEndpoint;
			public string LsEndpoint
			{
				get => _lsEndpoint;
                set
				{
					if (_lsEndpoint != value)
					{
						_lsEndpoint = value;
						RaisePropertyChanged("LsEndpoint");
					}
				}
			}

			private string _password;
			public string Password
			{
				get => _password;
                set
				{
					if (_password != value)
					{
						_password = value;
						RaisePropertyChanged("Password");
					}
				}
			}

			private string _apiKey;
			public string ApiKey
			{
				get => _apiKey;
                set
				{
					if (_apiKey != value)
					{
						_apiKey = value;
						RaisePropertyChanged("ApiKey");
					}
				}
			}


			private decimal? _profitLoss;
			public decimal? ProfitLoss
			{
				get => _profitLoss;
                set
				{
					if (_profitLoss != value)
					{
						_profitLoss = value;
						RaisePropertyChanged("ProfitLoss");
					}
				}
			}

			private decimal? _deposit;
			public decimal? Deposit
			{
				get => _deposit;
                set
				{
					if (_deposit != value)
					{
						_deposit = value;
						RaisePropertyChanged("Deposit");
					}
				}
			}

			private decimal? _usedMargin;
			public decimal? UsedMargin
			{
				get => _usedMargin;
                set
				{
					if (_usedMargin != value)
					{
						_usedMargin = value;
						RaisePropertyChanged("UsedMargin");
					}
				}
			}

			private decimal? _amountDue;
			public decimal? AmountDue
			{
				get => _amountDue;
                set
				{
					if (_amountDue != value)
					{
						_amountDue = value;
						RaisePropertyChanged("AmountDue");
					}
				}
			}

			private decimal? _availableCash;
			public decimal? AvailableCash
			{
				get => _availableCash;
                set
				{
					if (_availableCash != value)
					{
						_availableCash = value;
						RaisePropertyChanged("AvailableCash");
					}
				}
			}

			private decimal? _balance;
			public decimal? Balance
			{
				get => _balance;
                set
				{
					if (_balance != value)
					{
						_balance = value;
						RaisePropertyChanged("Balance");
					}
				}
			}

		}

		public class BrowseModel : PropertyChanged
		{
			private InstrumentModel _model;
			public InstrumentModel Model
			{
				get => _model;
                set
				{
					if (_model != value && value != null)
					{
						_model = value;
						RaisePropertyChanged("Model");
					}
				}
			}
		}

		public class WatchlistModel : PropertyChanged
		{
			private string _watchlistName;
			public string WatchlistName
			{
				get => _watchlistName;
                set
				{
					if (_watchlistName != value && value != null)
					{
						_watchlistName = value;
						RaisePropertyChanged("WatchlistName");
					}
				}
			}

			private string _watchlistId;
			public string WatchlistId
			{
				get => _watchlistId;
                set
				{
					if (_watchlistId != value && value != null)
					{
						_watchlistId = value;
						RaisePropertyChanged("WatchlistId");
					}
				}
			}

			private bool _editable;
			public bool Editable
			{
				get => _editable;
                set
				{
					if (_editable != value)
					{
						_editable = value;
						RaisePropertyChanged("Editable");
					}
				}
			}

			private bool _deletable;
			public bool Deletable
			{
				get => _deletable;
                set
				{
					if (_deletable != value)
					{
						_deletable = value;
						RaisePropertyChanged("Deletable");
					}
				}
			}

		}

		public class PositionModel : PropertyChanged
		{
			private string _createdDate;
			public string CreatedDate
			{
				get => _createdDate;
                set
				{
					if (_createdDate != value && value != null)
					{
						_createdDate = value;
						RaisePropertyChanged("CreatedDate");
					}
				}
			}

			private decimal? _dealSize;
			public decimal? DealSize
			{
				get => _dealSize;
                set
				{
					if (_dealSize != value)
					{
						_dealSize = value;
						RaisePropertyChanged("DealSize");
					}
				}
			}

			private string _direction;
			public string Direction
			{
				get => _direction;
                set
				{
					if (_direction != value)
					{
						_direction = value;
						RaisePropertyChanged("Direction");
					}
				}
			}



			private decimal? _openLevel;
			public decimal? OpenLevel
			{
				get => _openLevel;
                set
				{
					if (_openLevel != value)
					{
						_openLevel = value;
						RaisePropertyChanged("OpenLevel");
					}
				}
			}

			private decimal? _stopLevel;
			public decimal? StopLevel
			{
				get => _stopLevel;
                set
				{
					if (_stopLevel != value)
					{
						_stopLevel = value;
						RaisePropertyChanged("StopLevel");
					}
				}
			}

			private decimal? _limitLevel;
			public decimal? LimitLevel
			{
				get => _limitLevel;
                set
				{
					if (_limitLevel != value)
					{
						_limitLevel = value;
						RaisePropertyChanged("LimitLevel");
					}
				}
			}

			private InstrumentModel _model;
			public InstrumentModel Model
			{
				get => _model;
                set
				{
					if (_model != value && value != null)
					{
						_model = value;
						RaisePropertyChanged("Model");
					}
				}
			}
		}

		public class OrderModel : PropertyChanged
		{
			private string _dealId;
			public string DealId
			{
				get => _dealId;
                set
				{
					if (_dealId != value && value != null)
					{
						_dealId = value;
						RaisePropertyChanged("DealId");
					}
				}
			}

			private decimal? _orderSize;
			public decimal? OrderSize
			{
				get => _orderSize;
                set
				{
					if (_orderSize != value)
					{
						_orderSize = value;
						RaisePropertyChanged("OrderSize");
					}
				}
			}

			private string _direction;
			public string Direction
			{
				get => _direction;
                set
				{
					if (_direction != value)
					{
						_direction = value;
						RaisePropertyChanged("Direction");
					}
				}
			}


			private string _creationDate;
			public string CreationDate
			{
				get => _creationDate;
                set
				{
					if (_creationDate != value && value != null)
					{
						_creationDate = value;
						RaisePropertyChanged("CreationDate");
					}
				}
			}

			private InstrumentModel _model;
			public InstrumentModel Model
			{
				get => _model;
                set
				{
					if (_model != value && value != null)
					{
						_model = value;
						RaisePropertyChanged("Model");
					}
				}
			}
		}

		public class WatchlistMarketModel : PropertyChanged
		{
			private string _updateTime;
			public string UpdateTime
			{
				get => _updateTime;
                set
				{
					if (_updateTime != value && value != null)
					{
						_updateTime = value;
						RaisePropertyChanged("UpdateTime");
					}
				}
			}

			private InstrumentModel _model;
			public InstrumentModel Model
			{
				get => _model;
                set
				{
					if (_model != value && value != null)
					{
						_model = value;
						RaisePropertyChanged("Model");
					}
				}
			}          

		}
	  
        public class ChartModel : PropertyChanged
        {
            private string _chartEpic;
            public string ChartEpic
            {
                get => _chartEpic;
                set
                {
                    if (_chartEpic != value)
                    {
                        _chartEpic = value;
                        RaisePropertyChanged("ChartEpic");
                    }
                }
            }

            private ChartHlocModel _offer;
            public ChartHlocModel Offer
            {
                get => _offer;
                set
                {
                    if (_offer != value)
                    {
                        _offer = value;
                        RaisePropertyChanged("Offer");
                    }
                }
            }

            private ChartHlocModel _bid;
            public ChartHlocModel Bid
            {
                get => _bid;
                set
                {
                    if (_bid != value)
                    {
                        _bid = value;
                        RaisePropertyChanged("Bid");
                    }
                }
            }

            private ChartHlocModel _lastTradedPrice;
            public ChartHlocModel LastTradedPrice
            {
                get => _lastTradedPrice;
                set
                {
                    if (_lastTradedPrice != value)
                    {
                        _lastTradedPrice = value;
                        RaisePropertyChanged("LastTradedPrice");
                    }
                }
            }

            private bool? _endOfConsolidation;
            public bool? EndOfConsolidation
            {
                get => _endOfConsolidation;
                set
                {
                    if (_endOfConsolidation != value)
                    {
                        _endOfConsolidation = value;
                        RaisePropertyChanged("EndOfConsolidation");
                    }
                }
            }

            private int? _tickCount;
            public int? TickCount
            {
                get => _tickCount;
                set
                {
                    if (_tickCount != value)
                    {
                        _tickCount = value;
                        RaisePropertyChanged("TickCount");
                    }
                }
            }

            /// <summary>
            /// Last traded volume
            /// </summary>
            /// 
            private decimal? _lastTradedVolume;
            public decimal? LastTradedVolume
            {
                get => _lastTradedVolume;
                set
                {
                    if (_lastTradedVolume != value)
                    {
                        _lastTradedVolume = value;
                        RaisePropertyChanged("LastTradedVolume");
                    }
                }                
            }

            /// <summary>
            /// Incremental trading volume
            /// </summary>
            private decimal? _incrimentalTradingVolume;
            public decimal? IncrimetalTradingVolume
            {
                get => _incrimentalTradingVolume;
                set
                {
                    if (_incrimentalTradingVolume != value)
                    {
                        _incrimentalTradingVolume = value;
                        RaisePropertyChanged("IncrimentalTradingVolume");
                    }
                }     
            }

            /// <summary>
            /// Update time (as milliseconds from the Epoch)
            /// </summary>
            private DateTime? _updateTime;
            public DateTime? UpdateTime
            {
                get => _updateTime;
                set
                {
                    if (_updateTime != value)
                    {
                        _updateTime = value;
                        RaisePropertyChanged("UpdateTime");
                    }
                }    
            }

            /// <summary>
            /// Mid open price for the day
            /// </summary>
            private decimal? _dayMidOpenPrice;
            public decimal? DayMidOpenPrice
            {
                get => _dayMidOpenPrice;
                set
                {
                    if (_dayMidOpenPrice != value)
                    {
                        _dayMidOpenPrice = value;
                        RaisePropertyChanged("DayMidOpenPrice");
                    }
                }                  
            }

            /// <summary>
            /// Change from open price to current (MID price)
            /// </summary>
            private decimal? _dayChange;
            public decimal? DayChange
            {
                get => _dayChange;
                set
                {
                    if (_dayChange != value)
                    {
                        _dayChange = value;
                        RaisePropertyChanged("DayChange");
                    }
                }        
                
            }

            /// <summary>
            /// Daily percentage change (MID price)
            /// </summary>
            private decimal? _dayChangePct;
            public decimal? DayChangePct
            {
                get => _dayChangePct;
                set
                {
                    if (_dayChangePct != value)
                    {
                        _dayChangePct = value;
                        RaisePropertyChanged("DayChangePct");
                    }
                }      
            }

            private decimal? _dayHigh;
            public decimal? DayHigh
            {
                get => _dayHigh;
                set
                {
                    if (_dayHigh != value)
                    {
                        _dayHigh = value;
                        RaisePropertyChanged("DayHigh");
                    }
                }                     
            }

            /// <summary>
            /// Daily low price (MID)
            /// </summary>
            private decimal? _dayLow;
            public decimal? DayLow
            {
                get => _dayLow;
                set
                {
                    if (_dayLow != value)
                    {
                        _dayLow = value;
                        RaisePropertyChanged("DayLow");
                    }
                }      
                
            }
        }



	    public class ChartHlocModel : PropertyChanged
        {
            private decimal? _high;
            public decimal? High
            {
                get => _high;
                set
                {
                    if (_high != value)
                    {
                        _high = value;
                        RaisePropertyChanged("High");
                    }
                }
            }

            private decimal? _low;
            public decimal? Low
            {
                get => _low;
                set
                {
                    if (_low != value)
                    {
                        _low = value;
                        RaisePropertyChanged("Low");
                    }
                }
            }

            private decimal? _open;
            public decimal? Open
            {
                get => _open;
                set
                {
                    if (_open != value)
                    {
                        _open = value;
                        RaisePropertyChanged("Open");
                    }
                }
            }

            private decimal? _close;
            public decimal? Close
            {
                get => _close;
                set
                {
                    if (_close != value)
                    {
                        _close = value;
                        RaisePropertyChanged("Close");
                    }
                }
            }                      
        }


		public class InstrumentModel : PropertyChanged
		{
			private ClientSentimentModel _clientSentiment;
			public ClientSentimentModel ClientSentiment
			{
				get => _clientSentiment;
                set
				{
					if (_clientSentiment != value)
					{
						_clientSentiment = value;
						RaisePropertyChanged("ClientSentiment");
					}
				}
			}

			private string _marketStatus;
			public string MarketStatus
			{
				get => _marketStatus;
                set
				{
					if (_marketStatus != value)
					{
						_marketStatus = value;
						RaisePropertyChanged("MarketStatus");
					}
				}
			}

			private string _lsItemName;
			public string LsItemName
			{
				get => _lsItemName;
                set
				{
					if (_lsItemName != value && value != null)
					{
						_lsItemName = value;
						RaisePropertyChanged("LsItemName");
					}
				}
			}


			private string _epic;
			public string Epic
			{
				get => _epic;
                set
				{
					if (_epic != value && value != null)
					{
						_epic = value;
						RaisePropertyChanged("Epic");
					}
				}
			}

			private decimal? _bid;
			public decimal? Bid
			{
				get => _bid;
                set
				{
					if (_bid != value)
					{
						_bid = value;
						RaisePropertyChanged("Bid");
					}
				}
			}

			private decimal? _offer;
			public decimal? Offer
			{
				get => _offer;
                set
				{
					if (_offer != value)
					{
						_offer = value;
						RaisePropertyChanged("Offer");
					}
				}
			}

			private decimal? _open;
			public decimal? Open
			{
				get => _open;
                set
				{
					if (_open != value)
					{
						_open = value;
						RaisePropertyChanged("Open");
					}
				}
			}

			private string _updateTime;

			public string UpdateTime
			{
				get => _updateTime;
                set
				{
					if (value != _updateTime)
					{
						_updateTime = value;
						RaisePropertyChanged("UpdateTime");
					}
				}
			}

			private string _instrumentName;
			public string InstrumentName
			{
				get => _instrumentName;
                set
				{
					if (_instrumentName != value)
					{
						_instrumentName = value;
						RaisePropertyChanged("InstrumentName");
					}
				}
			}


			private decimal? _netChange;
			public decimal? NetChange
			{
				get => _netChange;
                set
				{
					if (_netChange != value)
					{
						_netChange = value;
						RaisePropertyChanged("NetChange");
					}
				}
			}

			private decimal? _pctChange;
			public decimal? PctChange
			{
				get => _pctChange;
                set
				{
					if (_pctChange != value)
					{
						_pctChange = value;
						RaisePropertyChanged("PctChange");
					}
				}
			}

			private decimal? _high;
			public decimal? High
			{
				get => _high;
                set
				{
					if (_high != value)
					{
						_high = value;
						RaisePropertyChanged("High");
					}
				}
			}

			private decimal? _low;
			public decimal? Low
			{
				get => _low;
                set
				{
					if (_low != value)
					{
						_low = value;
						RaisePropertyChanged("Low");
					}
				}
			}


			private bool? _streamingPricesAvailable;
			public bool? StreamingPricesAvailable
			{
				get => _streamingPricesAvailable;
                set
				{
					if (_streamingPricesAvailable != value)
					{
						_streamingPricesAvailable = value;
						RaisePropertyChanged("StreamingPricesAvailable");
					}
				}
			}
		}
	}
}
