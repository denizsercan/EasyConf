using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalProject
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //object kullanici = Session["kullaniciadi"];
            User kullanici = (User)Session["user"];
            if (kullanici != null)
            {
                pnlgiris.Visible = false;
                pnlkullanici.Visible = true;
                lblKullaniciAdi.Text = kullanici.name + " " + kullanici.surname;
                //lblKullaniciAdi.Text = kullanici.ToString();
            }
            else
            {
                pnlkullanici.Visible = false;
                pnlgiris.Visible = true;

            }

            KonferanslariGetir();
        }

        private void KonferanslariGetir()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Select Top 4 Id, conferenceName, conferencePlace, conferenceDate from Conferences order by Id desc";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);

            cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            lstkonferans.DataSource = dr;
            lstkonferans.DataBind();

            cnn.Close();
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Session.Contents.RemoveAll();

            System.Web.Security.FormsAuthentication.SignOut();

            Response.Redirect("/home.aspx");


        }



        protected void lbSelect_Click(object sender, EventArgs e)
        {
            Server.Transfer("conferenceDetail.aspx");
            
        }

        protected void lstkonferans_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "GetData")
            {
                if (e.CommandSource is LinkButton)
                {
                    ListViewDataItem item = (e.CommandSource as LinkButton).NamingContainer
                                             as ListViewDataItem;
                    Label ConfId = item.FindControl("labelId") as Label;
                    //Label Label5 = item.FindControl("Label5") as Label;
                    //and so on..
                    Session["ConfData"] = ConfId.Text;
                    Response.Redirect("conferenceDetail.aspx");
                    
                }
            }
        }
    }
}