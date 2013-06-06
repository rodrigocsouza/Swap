using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwapMobileWWW.MO
{
    public partial class ListaMOs : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
        
                //GridView1.DataSource = HumanHelper.ListaMos();
                //GridView1.DataBind();
                ASPxGridView1.DataSource = HumanHelper.ListaMos();
                ASPxGridView1.DataBind();
        
        }
    }
}