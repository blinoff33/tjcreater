using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TJCreater
{
	class TimerServiceLogic
	{
		private const string DEFAULT_TIMER_SERVICE_CONTROLLER_NAME = "SPTimerV4";

		public static void RestartTimerService(string timerServiceControllerName = DEFAULT_TIMER_SERVICE_CONTROLLER_NAME)
		{
			try
			{
				Console.WriteLine("restartTimerService run");
				ServiceController sc = new ServiceController(timerServiceControllerName);

				if (sc.Status == ServiceControllerStatus.Running)
				{
					sc.Stop();
					sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 5, 0));
					sc.Start();
					sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 5, 0));
				}
				else if (sc.Status == ServiceControllerStatus.Stopped)
				{
					sc.Start();
					sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 5, 0));
				}
				Console.WriteLine("restartTimerService success");
			}
			catch (Exception e)
			{
				Console.Write(e.Message);
			}
		}
	}
}
