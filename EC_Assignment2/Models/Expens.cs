
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace EC_Assignment2.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Expens
{

    public int expenseID { get; set; }

    public int targetYear { get; set; }

    public int targetMonth { get; set; }

    public int accountID { get; set; }

    public decimal amountAnticipated { get; set; }

    public Nullable<decimal> amount { get; set; }

    public string userName { get; set; }



    public virtual Account Account { get; set; }

}

}
