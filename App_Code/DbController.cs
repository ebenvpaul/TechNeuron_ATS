﻿using System;
using System.IO;
using System.Net;


namespace TechNeuron_ATS.App_Code
{
    public class DbController
    {
        public static string API_URL = "http://ebenvarghesepaul-001-site1.dtempurl.com";



        public string GetJobs()
        {
            try
            {
                
                var domainName = API_URL;
                HttpWebRequest request = (HttpWebRequest)WebRequest.
                                        Create(String.Format("{0}/api/JobMaster/GetAllJobs",
                                        domainName));
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var jsonResponse = reader.ReadToEnd();
                return jsonResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return ex.Message.ToString();
            }
        }



        public string GetSkillSet()
        {
            try
            {

                var domainName = API_URL;
                HttpWebRequest request = (HttpWebRequest)WebRequest.
                                        Create(String.Format("{0}/api/SkillSet/GetAllSkillSet",
                                        domainName));
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var jsonResponse = reader.ReadToEnd();
                return jsonResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return ex.Message.ToString();
            }
        }








        public string GetRanks()
        {
            try
            {

                var domainName = API_URL;
                HttpWebRequest request = (HttpWebRequest)WebRequest.
                                        Create(String.Format("{0}/api/Rank/GetAllRank",
                                        domainName));
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var jsonResponse = reader.ReadToEnd();
                return jsonResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return ex.Message.ToString();
            }
        }

    }






}

