using System.Collections.Generic;

namespace dto.endpoint.browse
{

public class BrowseMarketsResponse{
	///<Summary>
	///Child market hierarchy nodes
	///</Summary>
	public List<HierarchyNode> nodes { get; set; }
	///<Summary>
	///List of markets (applicable only to leaf nodes of the hierarchy tree)
	///</Summary>
	public List<HierarchyMarket> markets { get; set; }
}
}
