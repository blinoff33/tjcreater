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
	static class TimerJobCreater
	{
		public static void Create(string assamblyName, string className, object[] TJCtorParams, SPJobDefinitionCollection jobsCollection, Hashtable properties, SPSchedule schedule = null)
		{
			TimerJobBuilder TJBuilder = new TimerJobBuilder();

			TJBuilder.CreateJob(assamblyName, className, TJCtorParams);
			TJBuilder.DeleteOldVersion(jobsCollection);
			TJBuilder.SetSchedule(schedule);
			TJBuilder.SetProperties(properties);
			TJBuilder.UpdateJob();
		}
	}
}
