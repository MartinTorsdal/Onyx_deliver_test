using System;
using System.Collections.Generic;

public class InvoiceGroup
{
    public DateTime IssueDate { get; set; }
    public List<Invoice> Invoices { get; set; }
}
