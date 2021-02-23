using System.Collections.Generic;

namespace dto.endpoint.watchlists.retrieve
{

public class WatchlistInstrumentsResponse{
	///<Summary>
	///List of watchlist markets
	///</Summary>
	public List<WatchlistMarket> markets { get; set; }
}
}
