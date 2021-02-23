using System.Collections.Generic;

namespace dto.endpoint.accountactivity.transaction
{

public class TransactionHistoryResponse{
	///<Summary>
	///List of transactions
	///</Summary>
	public List<Transaction> transactions { get; set; }
}
}
