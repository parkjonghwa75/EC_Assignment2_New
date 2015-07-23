using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC_Assignment2.Models;
using System.Web.ModelBinding;

namespace EC_Assignment2.admin
{
    public partial class accountMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                using (comp2007Entities db = new comp2007Entities())
                {
                    var categoryDDL = from c in db.Categories select new { c.CategoryID, c.CategoryName };
                    ddlCategory.DataSource = categoryDDL.ToList();
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "Select");
                }
                getAccountMod();
            }
            else if (!IsPostBack)
            {
                using (comp2007Entities db = new comp2007Entities())
                {
                    var categoryDDL = from c in db.Categories select new { c.CategoryID, c.CategoryName };
                    ddlCategory.DataSource = categoryDDL.ToList();
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "Select");
                }
            }
        }


        protected void getAccountMod()
        {
            //
            Int32 AccountID = Convert.ToInt32(Request.QueryString["AccountID"]);

            //connect to db via EF
            using (comp2007Entities db = new comp2007Entities())
            {
                //
                Account a = (from objS in db.Accounts
                             where objS.AccountID == AccountID
                            select objS).FirstOrDefault();

                //map the student properties to the form controls if we found a match
                if (a != null)
                {

                    ddlCategory.SelectedIndex = a.CategoryID;
                    //ddlDepartment.SelectedValue=
                    txtAccountName.Text = a.AccountName;
                    if(a.isActive){
                        ckbIsActive.Checked=true;
                    }
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect to SQL Server
            using (comp2007Entities db = new comp2007Entities())
            {

                //use the Student model to save the new record
                Account a = new Account();
                Int32 AccountID = 0;

                //check the querystring for an id so we can determine add / update
                if (Request.QueryString["AccountID"] != null)
                {
                    //get the id from the url
                    AccountID = Convert.ToInt32(Request.QueryString["AccountID"]);

                    //get the current student from EF
                    a = (from objS in db.Accounts
                         where objS.AccountID == AccountID
                         select objS).FirstOrDefault();
                }

                a.CategoryID = Convert.ToInt32(ddlCategory.SelectedIndex);
                a.AccountName = txtAccountName.Text;
                if (ckbIsActive.Checked)
                {
                    a.isActive = true;
                }
                else
                {
                    a.isActive = false;
                }

                //call add only if we have no student ID
                if (AccountID == 0)
                {
                    db.Accounts.Add(a);
                }

                //run the update or insert
                db.SaveChanges();

                //redirect to the updated students page
                Response.Redirect("account.aspx");
            }
        }


    }
}