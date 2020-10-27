using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechNeuron_ATS.App_Code;
using TechNeuron_ATS.Model;

namespace TechNeuron_ATS.Site
{
    public partial class Jobs : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }

        }

        private void InitPage()
        {
            JobID.Text = string.Empty;
            txtjobdesc.Text = string.Empty;
            txtjobtitle.Text = string.Empty;
            LoadGVJobs();
        }

        private void LoadGVJobs()
        {
            PopulateGridView();
        }


        private void PopulateGridView()
        {
            var str_JobMaster = "";
            try
            {
                DbController ObjMain = new DbController();
                str_JobMaster = ObjMain.GetJobs();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<JobMaster>>(str_JobMaster);

                GDJobs.DataSource = myDeserializedClass2;
                GDJobs.DataBind();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }

              private void UpdateForm()
        {
          
        }

        protected void GDJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GDJobs.Rows[index];
            
            JobID.Text = GDJobs.Rows[index].Cells[1].Text;
           txtjobtitle.Text = GDJobs.Rows[index].Cells[2].Text;
            txtjobdesc.Text = GDJobs.Rows[index].Cells[3].Text;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateForm() != true)
            {
                return;
            }

            var reponse = "";

            if (JobID.Text.Trim() == string.Empty)
            {
                try
                {
                    var jobMaster = new JobMaster
                    {
                        JobId = 0,
                        JobTitle = txtjobtitle.Text,
                        JobDescription = txtjobdesc.Text,
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.addJobMaster(jobMaster);
                    ERR_MSG("Job Saved", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }


            if (JobID.Text.Trim() != string.Empty)
            {
                try
                {
                    var jobMaster = new JobMaster
                    {
                        JobId = Int32.Parse(JobID.Text),
                        JobTitle = txtjobtitle.Text,
                        JobDescription = txtjobdesc.Text,
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.UpdateJob(jobMaster);
                    ERR_MSG("Job Updated", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }

            LoadGVJobs();


        }


        private bool validateForm()
        {

            try
            {


                if (txtjobtitle.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter Job Title", true);
                    return false;
                }



                if (txtjobdesc.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter Job Desc", true);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ERR_MSG(ex.Message);
                return false;
            }
            finally
            {

            }
        }





        private void ERR_MSG(string strErr, bool isError = true)
        {
            try
            {

                if (!isError)
                {

                    AlertifySuccess(strErr);
                }
                else
                    AlertifyError(strErr);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        public void AlertifyError(string strErr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("alertifyError('" + strErr + "');");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", sb.ToString(), false);
        }

        public void AlertifySuccess(string strErr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("alertifySuccess('" + strErr + "');");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", sb.ToString(), false);
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            InitPage();
        }
    }
}