using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJCreater
{
	class DefaultValues
	{

		/// <summary>
		/// Получение Properties с SiteId и WebId для запуска таймерджоба
		/// </summary>
		/// <param name="site">SPSite</param>
		/// <param name="web">SPWeb</param>
		/// <returns></returns>
		public static Hashtable GetProperties(SPSite site, SPWeb web)
		{
			Hashtable properties = new Hashtable();
			properties.Add("SiteId", site.ID);
			properties.Add("WebId", web.ID);

			return properties;
		}

		public static SPSchedule GetSchedule()
		{
			return new SPOneTimeSchedule(DateTime.Now.AddMinutes(5));
		}

		public static object[] GetInputParams(SPSite site)
		{
			List<object> inputParams = new List<object>();
			inputParams.Add(site.WebApplication);
			inputParams.Add(SPServer.Local);
			inputParams.Add(SPJobLockType.Job);

			return inputParams.ToArray();
		}

		public static SPJobDefinitionCollection GetAllJobs(SPSite site)
		{
			return site.WebApplication.JobDefinitions;
		}
	}
}
