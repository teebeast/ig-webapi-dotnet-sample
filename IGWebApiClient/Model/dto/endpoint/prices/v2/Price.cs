namespace dto.endpoint.prices.v2
{

public class Price{
	///<Summary>
	///Bid price
	///</Summary>
	public decimal? bid { get; set; }
	///<Summary>
	///Ask price
	///</Summary>
	public decimal? ask { get; set; }
	///<Summary>
	///Last traded price.  This will generally be null for non exchange-traded instruments
	///</Summary>
	public decimal? lastTraded { get; set; }
}
}
