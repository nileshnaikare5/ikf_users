using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Userwebapp;

namespace Userwebapp
{
    public partial class Default : System.Web.UI.Page
    {
        BAL bal = new BAL();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            using (DataTable dt = bal.GetUsers())
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void Insert(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string dob = txtDob.Text;
            string designation = txtDesignation.Text;
            string skills = string.Empty;            
            foreach (ListItem item in ddlSkills.Items)
            {
                if (item.Selected)
                {
                    skills += item.Text + ",";

                }
            }
            skills.Replace(",", " ");
            txtName.Text = "";
            txtDob.Text = "";
            txtDesignation.Text = "";
            bal.AUD_User(0, name, dob, designation, skills, "I");
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("txtName") as TextBox).Text;
            string dob = (row.FindControl("txtDob") as TextBox).Text;
            string designation = (row.FindControl("txtDesignation") as TextBox).Text;
            string skills = string.Empty;
            ListBox cblSkilss = (ListBox)(row.FindControl("ddlSkills"));
            foreach (ListItem item in cblSkilss.Items)
            {
                if (item.Selected)
                {
                    skills += item.Text + ",";

                }
            }
            skills.Replace(",", " ");
            bal.AUD_User(userId, name, dob, designation, skills, "U");
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            bal.AUD_User(userId, "", "", "", "", "D");
            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[4].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

    }
}