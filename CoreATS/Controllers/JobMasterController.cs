using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Model;
using CoreATS.Repository;
using CoreATS.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreATS.Controllers
{
    [Produces("application/json")]
    [Route("api/JobMaster")]
    public class JobMasterController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public JobMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetAllJobs")]
        public IActionResult GetAllJobs()
        {
            var data = DbClientFactory<JobMasterDbClient>.Instance.GetAllJobs(appSettings.Value.DbConn);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetJobById/{JobId?}")]
        public IActionResult GetJobById(int JobId)
        {
            var data = DbClientFactory<JobMasterDbClient>.Instance.GetJobById(JobId, appSettings.Value.DbConn);
            return Ok(data);
        }

       


        [HttpPost]
        [Route("SaveJob")]
        public IActionResult SaveJob([FromBody] JobMaster model)
        {
            var msg = new Message<JobMaster>();
            var data = DbClientFactory<JobMasterDbClient>.Instance.SaveJob(model, appSettings.Value.DbConn);
            if (data == null || data == String.Empty)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Job Saving Failed";

            }
            else
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Job saved successfully";
            }
            return Ok(data);
        }







        [HttpPut]
        [Route("UpdateJob")]
        public IActionResult UpdateJob([FromBody] JobMaster model)
        {
            var msg = new Message<JobMaster>();
            var data = DbClientFactory<JobMasterDbClient>.Instance.UpdateJob(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.JobId == 0)
                    msg.ReturnMessage = "Job saved successfully";
                else
                    msg.ReturnMessage = "Job updated successfully";
            }
            //else if (data == "C201")
            //{
            //    msg.IsSuccess = false;
            //    msg.ReturnMessage = "Email Id already exists";
            //}
            //else if (data == "C202")
            //{
            //    msg.IsSuccess = false;
            //    msg.ReturnMessage = "Mobile Number already exists";
            //}
            return Ok(msg);
        }

         
    }
}