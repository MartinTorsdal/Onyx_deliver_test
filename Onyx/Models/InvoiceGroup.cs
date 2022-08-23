using System;
using System.Collections.Generic;

class InvoiceGroup
{
    public DateTime IssueDate { get; set; }
    public List<Invoice> Invoices { get; set; }
}
