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
    [Route("api/Rank")]
    public class RankController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public RankController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetAllRank")]
        public IActionResult GetAllRank()
        {
            var data = DbClientFactory<RankDbClient>.Instance.GetAllRanks(appSettings.Value.DbConn);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetRankById/{RankingId?}")]
        public IActionResult GetRankById(int RankingId)
        {
            var data = DbClientFactory<RankDbClient>.Instance.GetRankById(RankingId, appSettings.Value.DbConn);
            return Ok(data);
        }

       


        [HttpPost]
        [Route("SaveRank")]
        public IActionResult SaveRank([FromBody] Rank model)
        {
            var msg = new Message<Rank>();
            var data = DbClientFactory<RankDbClient>.Instance.SaveRank(model, appSettings.Value.DbConn);
            if (data == null || data == String.Empty)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Rank Saving Failed";

            }
            else
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Rank saved successfully";
            }
            return Ok(data);
        }







        [HttpPut]
        [Route("UpdateRank")]
        public IActionResult UpdateRank([FromBody] Rank model)
        {
            var msg = new Message<Rank>();
            var data = DbClientFactory<RankDbClient>.Instance.UpdateRank(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                if (model.RankingId == 0)
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




      
    }
}