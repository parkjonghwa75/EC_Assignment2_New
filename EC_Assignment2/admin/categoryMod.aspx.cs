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
    public partial class categoryMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if save wasn't click AND we have a studentID in the url
            if (!IsPostBack && (Request.QueryString.Count > 0))
            {
                getCategoryDetail();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // use EF to connect to SQL
            using (comp2007Entities db = new comp2007Entities())
            {
                //use the student model to save the new model
                Category c = new Category();
                Int32 CategoryID = 0;

                //check save? or update??
                if (Request.QueryString["CategoryID"] != null)
                {
                    //get the id from the url
                    CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                    //get the current student from EF   
                    c = (from objS in db.Categories
                         where objS.CategoryID == CategoryID
                         select objS).FirstOrDefault();
                }

                c.CategoryName = txtCtgname.Text;

                if (ckbIsExpense.Checked)
                {
                    c.isExpense = true;
                }
                else
                {
                    c.isExpense = false;
                }

                if (ckbActivated.Checked)
                {
                    c.isActive = true;
                }
                else
                {
                    c.isActive = false;
                }

                if (CategoryID == 0)
                {
                    db.Categories.Add(c);
                }

                db.SaveChanges();

                //redirect to the updated list page
                Response.Redirect("category.aspx");

            }
        }


        protected void getCategoryDetail()
        {
            //populate form with existing student record
            Int32 CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);

            //connect to db via EF
            using (comp2007Entities db = new comp2007Entities())
            {
                //populate a student instance with the student ID from the url parameter
                Category c = (from objS in db.Categories
                                where objS.CategoryID == CategoryID
                                select objS).FirstOrDefault();

                //map the student to the form controls when s found
                if (c != null)
                {
                    txtCtgname.Text = c.CategoryName;
                    if(c.isExpense){
                        ckbIsExpense.Checked = true;
                    }
                    if (c.isActive)
                    {
                        ckbActivated.Checked = true;
                    }
                   

                }

            }
        }
    }


}