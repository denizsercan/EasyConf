using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalProject
{
    public partial class rewiverPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Object rewiver = Session["kullaniciadi"];


                if (checkActiveRewiver(rewiver.ToString()))
                {
                    Response.Redirect("home.aspx");

                }
                else {
                 this.PopulateCheckBox(rewiver.ToString());
                }


                
            }
        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtSurname.Text != "" && txtPassword.Text != "" )
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                Object rewiver = Session["kullaniciadi"];

                

                String sorgu = "UPDATE Rewivers SET name = @name, surname = @surname, password = @password, degree = @degree, status = 1 WHERE email = @email";



                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                cnn.Open();
                try
                {

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@degree", txtDegree.Text);
                    cmd.Parameters.AddWithValue("@email", rewiver.ToString());

                    cmd.ExecuteNonQuery();

                    cnn.Close();

                    foreach (ListItem item in chkInterest.Items)
                    {
                        if (item.Selected) {
                            AddInterests(rewiver.ToString(), item.Text);
                        }
                   }

                    lblSonuc.Text = "Bilgileriniz Güncellendi.";
                }
                catch (Exception)
                {

                    lblSonuc.Text = "Bilgileriniz Güncellenemedi.";

                }
            }
            else { lblSonuc.Text = "Boş Alanları Doldurunuz."; }



           


    }

        private void PopulateCheckBox(string email)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_BindCheckBox", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@reviwerEmail", email));

                // execute the command
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["topic"].ToString();
                        item.Value = sdr["Id"].ToString();
                       // item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                        chkInterest.Items.Add(item);
                    }
                }
                conn.Close();



            }
        }

        private void AddInterests(string email, string interestTopic)
        {
            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
           


            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("SP_InterestEkle", con);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@reviwerEmail", email));
                cmd.Parameters.Add(new SqlParameter("@interestTopic", interestTopic));

                cmd.ExecuteNonQuery();
                con.Close();

            }

    }


        private bool checkActiveRewiver(string email)
        {


            bool active = false;



            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_CheckRewiverActivated", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@reviwerEmail", email));

                // execute the command
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read()) {

                        if (sdr["status"].ToString() == "1")
                        {

                            active = true;

                        }

                    }

                }
                conn.Close();

                return active;

            }
        }


    }
}