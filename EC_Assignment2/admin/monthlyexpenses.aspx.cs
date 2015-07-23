using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ref model binding
using EC_Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;


namespace EC_Assignment2.admin
{
    public partial class monthlyexpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate departments list
            if (!IsPostBack)
            {
                Session["SortColumn"] = "CategoryName";
                Session["SortDirection"] = "ASC";
                getMonthly();
            }
        }

        protected void grdMonthly_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            getMonthly();


            //toggle the sort direction
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }


        protected void getMonthly()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();
                Int32 targetMonth = Convert.ToInt32(ddlMonth.SelectedValue);
                Int32 targetYear = Convert.ToInt32(ddlYear.SelectedValue);


                var objE = (from a in db.Accounts
                            select new { a.Category.CategoryName, a.AccountName });

                //bind the result to the gridview
                grdMonthly.DataSource = objE.AsQueryable().OrderBy(SortString).ToList();
                grdMonthly.DataBind();
            }

        }

    }
}