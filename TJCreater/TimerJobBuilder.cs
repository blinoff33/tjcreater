using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TJCreater
{
	class TimerJobBuilder
	{
		public SPJobDefinition Timerjob { get; set; }

		public void CreateJob(string assamblyName, string className, object[] ctorParameters = null)
		{
			this.Timerjob = (SPJobDefinition)ReflectionLogic.CreateClassInstance(assamblyName, className, ctorParameters);
		}

		/// <summary>
		/// Удаление таймерджоба
		/// </summary>
		/// <param name="site">SPSite</param>
		/// <param name="DocJobName">Название таймеджоба</param>
		public void DeleteOldVersion(SPJobDefinitionCollection jobsCollection = null)
		{
			foreach (SPJobDefinition job in jobsCollection)
			{
				if (job.Name == this.Timerjob.Title)
				{
					job.Delete();
				}
			}
		}

		public void SetSchedule(SPSchedule schedule)
		{
			if (schedule == null) schedule = DefaultValues.GetSchedule();
			this.Timerjob.Schedule = schedule;
		}

		public void SetProperties(Hashtable properties)
		{
			foreach (var key in properties.Keys)
			{
				this.Timerjob.Properties.Add(key, properties[key]);
			}
		}

		public void UpdateJob()
		{
			this.Timerjob.Update();
		}

	}
}
