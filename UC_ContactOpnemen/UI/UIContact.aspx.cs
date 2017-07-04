using Microsoft.AspNet.Identity;
using System;
using UC_ContactOpnemen.CC;

namespace UC_ContactOpnemen.UI
{
    public partial class UIContact : System.Web.UI.Page
    {
        private static string _userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            //Check if user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                if (!cbAnoniem.Checked)
                {
                    //UserID verkrijgen
                    _userID = User.Identity.GetUserId();
                    tbName.Text = User.Identity.GetUserName();
                    tbEmail.Text = new CCContactOpnemen().GetEmailAdress(_userID);
                }
                //Gebruiker heeft anoniem aangevinkt, dus _user wordt null
                else
                {
                    _userID = null;
                }

                //De attribute onclick zorgt voor een popup in het scherm
                //Dit scherm laat weten dat de gebruiker niet is ingelogd en vraagt of hij/zij dit nog wilt doen
                //Omdat de gebruiker ingelogd is hoeft dit niet gevraagd te worden
                btSend.Attributes.Remove("onclick");
            }
            //If no user is authenticated
            else
            {
                //Als er geen gebruiker is ingelogd wordt _user null
                _userID = null;
                //De attribute onclick zorgt voor een popup in het scherm
                //Dit scherm laat weten dat de gebruiker niet is ingelogd en vraagt of hij/zij dit nog wilt doen
                //Gebruiker vragen of hij of zij wilt inloggen
                btSend.Attributes.Add("onclick", "return ConfirmOnClick()");

                if (cbAnoniem.Checked)
                {
                    //Omdat de gebruiker anoniem wilt zijn wordt dit attribuut verwijderd
                    btSend.Attributes.Remove("onclick");
                }
            }
        }

        /// <summary>
        /// This method creates a new instance of CCContactopnemen and invokes the method GetSupervisors()
        /// The gridview gets the DataSource from the method GetSupervisors() as a datatable
        /// </summary>
        private void BindGrid()
        {
            CCGetSupervisors gs = new CCGetSupervisors();
            gvGetSupervisors.DataSource = gs.ReturnSupervisors();
            gvGetSupervisors.DataBind();
        }

        /// <summary>
        /// This method creates a new instance of CCContactopnemen and invokes the method SaveMail(....)
        /// If successful; a popup shows that mail has been sent successfully
        /// If not successful; a popup shows that mail has not been sent successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This is a Method that invokes when the checkbox "Anoniem" has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbAnoniem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnoniem.Checked)
            {
                tbName.Text = "Anoniem";
                tbName.Enabled = false;
                tbName.Visible = false;
                lbName.Visible = false;

                tbEmail.Text = "anoniem.anoniem@a.com";
                tbEmail.Enabled = false;
                tbEmail.Visible = false;
                lbEmail.Visible = false;
            }

            else
            {
                tbName.Text = "";
                tbName.Enabled = true;
                tbName.Visible = true;
                lbName.Visible = true;

                tbEmail.Text = "";
                tbEmail.Enabled = true;
                tbEmail.Visible = true;
                lbEmail.Visible = true;
            }
        }
    }
}