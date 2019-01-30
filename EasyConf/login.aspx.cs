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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //object kullanici = Session["kullaniciadi"];
            //if (kullanici != null)
            //{
            //    pnlgiris.Visible = false;                
            //}
           
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

            if ( txtPassword.Text != "" && txtEmail.Text != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "Select * From Users Where email = @email AND password = @password";

                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                
      
                    cnn.Open();

                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                   

                    User u = new User();
                    u.Id = Convert.ToInt32(dr["Id"]);
                    u.name = dr["name"] != DBNull.Value ? dr["name"].ToString() : string.Empty;
                    u.surname = dr["surname"] != DBNull.Value ? dr["surname"].ToString() : string.Empty;
                    u.email = dr["email"] != DBNull.Value ? dr["email"].ToString() : string.Empty;
                    Session["user"] = u;
                    Response.Redirect("~/home.aspx");

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
