using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC_Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace EC_Assignment2.admin
{
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate departments list
            if (!IsPostBack)
            {
                Session["SortColumn"] = "CategoryName";
                Session["SortDirection"] = "ASC";
                getCategory();
            }
        }

        protected void getCategory()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                var categories = from objS in db.Categories
                                  select objS;

                //bind the result to the gridview
                grdCategory.DataSource = categories.AsQueryable().OrderBy(SortString).ToList();
                grdCategory.DataBind();
            }

        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCategory.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getCategory();
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            getCategory();
        }

        protected void grdCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            getCategory();


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

        protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdCategory.Columns.Count - 1; i++)
                    {
                        if (grdCategory.Columns[i].SortExpression == Session["SortColumn"].ToString())
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
        }

    }
}