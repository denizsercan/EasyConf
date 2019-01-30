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
    public partial class RewiverLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object kullanici = Session["kullaniciadi"];
            if (kullanici != null)
            {
                pnlgiris.Visible = false;

            }

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text != "" && txtEmail.Text != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "Select * From Rewivers Where email = @email AND password = @password";

                SqlCommand cmd = new SqlCommand(sorgu, cnn);



                cnn.Open();

                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session.Timeout = 300;
                    Session.Add("kullaniciadi", dr["email"].ToString());
                    Response.Redirect("rewiverPage.aspx");

                }
                else {

                    lblSonuc.Text = "Kullanıcı Girişi Sağlanamadı.";

                }

                cnn.Close();



            }
            else { lblSonuc.Text = "Boş Alanları Doldurunuz."; }


        }
    }
}
