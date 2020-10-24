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
    [Route("api/SkillSet")]
    public class SkillSetController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public SkillSetController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetAllSkillSet")]
        public IActionResult GetAllCandidates()
        {
            var data = DbClientFactory<SkillSetDbClient>.Instance.GetAllSkillSet(appSettings.Value.DbConn);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetSkillSetById/{SkillId?}")]
        public IActionResult GetUserId(int SkillId)
        {
            var data = DbClientFactory<SkillSetDbClient>.Instance.GetSkillSetById(SkillId, appSettings.Value.DbConn);
            return Ok(data);
        }

       


        [HttpPost]
        [Route("SaveSkillSet")]
        public IActionResult SaveSkillSet([FromBody] SkillSet model)
        {
            var msg = new Message<SkillSet>();
            var data = DbClientFactory<SkillSetDbClient>.Instance.SaveSkillSet(model, appSettings.Value.DbConn);
            if (data == null || data == String.Empty)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "SkillSet Saving Failed";

            }
            else
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "SkillSet saved successfully";
            }
            return Ok(data);
        }







        [HttpPut]
        [Route("UpdateSkillSet")]
        public IActionResult UpdateSkillSet([FromBody] SkillSet model)
        {
            var msg = new Message<SkillSet>();
            var data = DbClientFactory<SkillSetDbClient>.Instance.UpdateSkillSet(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.SkillId == 0)
                    msg.ReturnMessage = "SkillSet saved successfully";
                else
                    msg.ReturnMessage = "SkillSet updated successfully";
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