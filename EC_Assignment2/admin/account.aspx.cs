using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//model references for EF
using EC_Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace EC_Assignment2.admin
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "AccountID";
                Session["SortDirection"] = "ASC";
                getAccounts();
            }
        }

        protected void getAccounts()
        {
            //connect to EF
            using (comp2007Entities db = new comp2007Entities())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //query the students table using EF and LINQ
                var Accounts = from n in db.Accounts
                               select new { n.AccountID, n.AccountName, n.Category.CategoryName,  n.isActive };

                //bind the result to the gridview

                grdAccounts.DataSource = Accounts.AsQueryable().OrderBy(SortString).ToList();
                grdAccounts.DataBind();

            }
        }


        protected void grdAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's Data Key collection
            Int32 AccountID = Convert.ToInt32(grdAccounts.DataKeys[selectedRow].Values["AccountID"]);

            //use EF to remove the selected student from the db
            using (comp2007Entities db = new comp2007Entities())
            {

                Account a = (from objS in db.Accounts
                             where objS.AccountID == AccountID
                            select objS).FirstOrDefault();

                //do the delete
                db.Accounts.Remove(a);
                db.SaveChanges();
            }

            //refresh the grid
            getAccounts();
        }

        protected void grdAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccounts.PageIndex = e.NewPageIndex;
            getAccounts();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdAccounts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getAccounts();
        }

        protected void grdAccounts_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            getAccounts();


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

        protected void grdAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdAccounts.Columns.Count - 1; i++)
                    {
                        if (grdAccounts.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    } // end of for
                }

            } // end of if
        } // end of grdCourses_RowDataBound


    }
}