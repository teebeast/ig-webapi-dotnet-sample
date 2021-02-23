using System.Collections.Generic;

namespace dto.endpoint.workingorders.get.v1
{

public class WorkingOrdersResponse{
	///<Summary>
	///List of working orders
	///</Summary>
	public List<WorkingOrder> workingOrders { get; set; }
}
}
