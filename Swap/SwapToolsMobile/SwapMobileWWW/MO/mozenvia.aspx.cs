using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwapMobileWWW.MO
{
    public partial class mozenvia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //http://localhost:1057/MO/mozenvia.aspx?id=999&from=552171259821&to=8522&msg=Oi&account=swap&date=02052013
            try
            {
                MOHuman mo = new MOHuman();
                mo.Id = Request.QueryString["id"];
                mo.From = Request.QueryString["from"];
                mo.To = Request.QueryString["to"];
                mo.Msg = Request.QueryString["msg"];
                mo.Account = Request.QueryString["account"];
                mo.Date_ = Request.QueryString["date"];
                SalvaResultado(mo);
                Response.Write("Ok");
            }
            catch (Exception exx)
            {
                Response.Write("Erro - " + exx.Message);
            }
        }

        private void SalvaResultado(MOHuman mo)
        {
            HumanHelper.SalvarMO(mo);
        }
    }
}