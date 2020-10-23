using CoreATS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Utility;

namespace CoreATS.Translators
{
    public static class JobMasterTranslator
    {
            public static JobMaster TranslateAsJobMaster(this SqlDataReader reader,bool isList = false)
        {
            if(!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new JobMaster();
                              
            if (reader.IsColumnExists("JobId"))
                item.JobId = SqlHelper.GetNullableInt32(reader, "JobId");
           
            if (reader.IsColumnExists("JobTitle"))
                item.JobTitle = SqlHelper.GetNullableString(reader, "JobTitle");

            if (reader.IsColumnExists("JobDescription"))
                item.JobDescription = SqlHelper.GetNullableString(reader, "JobDescription");

            if (reader.IsColumnExists("IsActive"))
                item.IsActive = SqlHelper.GetBoolean(reader, "IsActive");


            if (reader.IsColumnExists("CreatedDate"))
                item.CreatedDate = SqlHelper.GetNullableDate(reader, "CreatedDate");

            return item;
        }

        public static List<JobMaster> TranslateAsJobMasterList(this SqlDataReader reader)
        {
            var list = new List<JobMaster>();
            while(reader.Read())
            {
                list.Add(TranslateAsJobMaster(reader, true));
            }
            return list;
        }
    }
}
