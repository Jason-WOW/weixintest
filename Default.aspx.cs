using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private readonly string Token = "weixin";
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth();
    }
    private void Auth()
    {
        string signature = Request["signature"];
        string timestamp = Request["timestamp"];
        string nonce = Request["nonce"];
        string echoste = Request["echostr"];
        if (Request.HttpMethod == "GET")
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                Response.Write(echoste);
            }
            else
            {
                Response.Write("kyi");
            }
        }
    }
}