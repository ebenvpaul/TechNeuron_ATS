using CoreATS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Utility;

namespace CoreATS.Translators
{
    public static class RanksTranslator
    {
        public static Rank TranslateAsRanks(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Rank();
                       
            if (reader.IsColumnExists("RankingId"))
                item.RankingId = SqlHelper.GetNullableInt32(reader, "RankingId");

            if (reader.IsColumnExists("RankingTitle"))
                item.RankingTitle = SqlHelper.GetNullableString(reader, "RankingTitle");

            if (reader.IsColumnExists("RankingDesc"))
                item.RankingDesc = SqlHelper.GetNullableString(reader, "RankingDesc");


            if (reader.IsColumnExists("MinRank"))
                item.MinRank = SqlHelper.GetNullableInt32(reader, "MinRank");


            if (reader.IsColumnExists("MaxRank"))
                item.MaxRank = SqlHelper.GetNullableInt32(reader, "MaxRank");


            if (reader.IsColumnExists("IsActive"))
                item.IsActive = SqlHelper.GetBoolean(reader, "IsActive");

            if (reader.IsColumnExists("CreatedDate"))
                item.CreatedDate = SqlHelper.GetNullableDate(reader, "CreatedDate");

            return item;
        }

        public static List<Rank> TranslateAsRankList(this SqlDataReader reader)
        {
            var list = new List<Rank>();
            while (reader.Read())
            {
                list.Add(TranslateAsRanks(reader, true));
            }
            return list;
        }
    }
}
