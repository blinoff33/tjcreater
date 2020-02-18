using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace TJCreater
{
	class Program
	{
		static void Main(string[] args)
		{
			const string SiteUrl		= "site_url";
			const string AssamblyName	= "assambly_name";
			const string ClassName		= "tj_class_name";

			Console.OutputEncoding = Encoding.GetEncoding(1251);

			using (SPSite site = new SPSite(SiteUrl))
			{
				using (SPWeb web = site.OpenWeb())
				{
					object[] TJCtorParams = DefaultValues.GetInputParams(site);
					SPJobDefinitionCollection jobsCollection = DefaultValues.GetAllJobs(site);
					Hashtable properties = DefaultValues.GetProperties(site, web);

					TimerJobCreater.Create(AssamblyName, ClassName, TJCtorParams, jobsCollection, properties);

					TimerServiceLogic.RestartTimerService();
				}
			}
			Console.WriteLine("End");
			Console.ReadKey();
		}

	}
}
