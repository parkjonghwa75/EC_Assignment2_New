
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
    
public partial class Account
{

    public Account()
    {

        this.Expenses = new HashSet<Expens>();

    }


    public int AccountID { get; set; }

    public string AccountName { get; set; }

    public int CategoryID { get; set; }

    public bool isActive { get; set; }



    public virtual ICollection<Expens> Expenses { get; set; }

    public virtual Category Category { get; set; }

}

}
