using System.Collections.Generic;

namespace dto.endpoint.positions.get.sprintmarkets.v1
{

public class SprintMarketsPositionsResponse{
	///<Summary>
	///The list of fast binary positions
	///</Summary>
	public List<SprintMarketPosition> sprintMarketPositions { get; set; }
}
}
