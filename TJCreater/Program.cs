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
			const string SiteUrl		= @"https://gpn-credit-control.15.prototype.spellabs.com";
			const string AssamblyName	= "Spellabs.GPN.CreditControl.TJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=038ea93179eb9a67";
			const string ClassName		= "Spellabs.GPN.CreditControl.TJ.AccontingReportLoaderTJ";

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
