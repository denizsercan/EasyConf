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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtSurname.Text != "" && txtPassword.Text != "" && txtEmail.Text != "" && DropDownList1.SelectedValue != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                String sorgu = "";

                if (DropDownList1.SelectedValue == "Conference Manager")
                {

                    sorgu = "Insert into Users (name, surname, password, email, degree, role) Values (@name, @surname, @password, @email, @degree, 0)";

                }
                else if (DropDownList1.SelectedValue == "Rewiver")
                {

                    sorgu = "Insert into Users (name, surname, password, email, degree, role) Values (@name, @surname, @password, @email, @degree, 1)";
                }
                else {

                    sorgu = "Insert into Users (name, surname, password, email, degree, role) Values (@name, @surname, @password, @email, @degree, 2)";
                }



                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();
                try
                {

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@degree", txtDegree.Text);

                    cmd.ExecuteNonQuery();

                    cnn.Close();

                    lblSonuc.Text = "Kayıt yapıldı.";
                }
                catch (Exception)
                {

                    lblSonuc.Text = "Kayıt yapılmadı.";

                }
            }
            else { lblSonuc.Text = "Boş Alanları Doldurunuz."; }

            
            }
    }
}                                                                                                                        