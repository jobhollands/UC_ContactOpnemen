using Microsoft.AspNet.Identity;
using System;
using UC_ContactOpnemen.CC;

namespace UC_ContactOpnemen.UI
{
    public partial class UIContact : System.Web.UI.Page
    {
        private bool _userIsLoggedIn;
        private string _userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checken of gebruiker is ingelogd
            _userIsLoggedIn = User.Identity.IsAuthenticated;
            if (_userIsLoggedIn)
            {
                //UserID verkrijgen
                _userID = User.Identity.GetUserId();
            }
            else
            {
                btSend.Attributes.Add("onclick", "return ConfirmOnDelete()");
            }
            

            //if (!this.IsPostBack)
            //{
            //    this.BindGrid();
            //}
        }

        //private void BindGrid()
        //{
        //    CCGetSupervisors gs = new CCGetSupervisors();
        //    gvGetSupervisors.DataSource = gs.ReturnSupervisors();
        //    gvGetSupervisors.DataBind();
        //}

        protected void btSend_Click(object sender, EventArgs e)
        {
            CCContactOpnemen co = new CCContactOpnemen();

            if (co.SaveMail(tbName.Text, tbEmail.Text, tbSubject.Text, tbMessage.Text, _userID))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Mail is succesvol verzonden');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Mail verzonden is mislukt');", true);
            }
        }

        protected void cbAnoniem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnoniem.Checked)
            {
                tbName.Text = "Anoniem";
                tbEmail.Text = "anoniem.anoniem@a.com";
            }

            else
            {
                tbName.Text = "";
                tbEmail.Text = "";
            }
        }
    }
}