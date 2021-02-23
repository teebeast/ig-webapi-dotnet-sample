namespace dto.endpoint.positions.get.otc.v2
{

public class OpenPosition{
	///<Summary>
	///Open position data
	///</Summary>
	public OpenPositionData position { get; set; }
	///<Summary>
	///Market data
	///</Summary>
	public MarketData market { get; set; }
}
}
