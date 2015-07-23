﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EC_Assignment2
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //detemine which nav to show
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                plhPublic.Visible = false;
                plhPrivate.Visible = true;
            }
            else
            {
                plhPublic.Visible = true;
                plhPrivate.Visible = false;
            }
        }
    }
}