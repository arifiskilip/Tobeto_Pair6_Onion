﻿namespace Domain.Entities
{
	public class CorporateCustomer : Customer
	{
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
}
