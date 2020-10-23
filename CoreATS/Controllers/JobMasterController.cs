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
        [Route("GetAllCandidates")]
        public IActionResult GetAllCandidates()
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetAllCandidates(appSettings.Value.DbConn);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetCandidatesById/{CandidateId?}")]
        public IActionResult GetUserId(int CandidateId)
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetCandidatesById(CandidateId, appSettings.Value.DbConn);
            return Ok(data);
        }

       


        [HttpPost]
        [Route("SaveCandidateMaster")]
        public IActionResult SaveCandidateMaster([FromBody] CandidatesModel model)
        {
            var msg = new Message<CandidatesModel>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveCandidateMaster(model, appSettings.Value.DbConn);
            if (data == null || data == String.Empty)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "User Saving Failed";

            }
            else
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User saved successfully";
            }
            return Ok(data);
        }







        [HttpPut]
        [Route("UpdateCandidateMaster")]
        public IActionResult UpdateCandidateMaster([FromBody] CandidatesModel model)
        {
            var msg = new Message<CandidatesModel>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateCandidatesMaster(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.CandidateId == 0)
                    msg.ReturnMessage = "Candidate saved successfully";
                else
                    msg.ReturnMessage = "Candidate updated successfully";
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





        [HttpPost]
        [Route("SaveCandidateDetails")]
        public IActionResult SaveCandidateDetails([FromBody] CandidatesModel model)
        {
            var msg = new Message<CandidatesModel>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveCandidateDetail(model, appSettings.Value.DbConn);
            if (data == null || data == String.Empty)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "User Saving Failed";

            }
            else
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User saved successfully";
            }
            return Ok(data);
        }
                       
    }
}