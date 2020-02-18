using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TJCreater
{
	class ReflectionLogic
	{
		public static object CreateClassInstance(string assamblyName, string className, object[] inputParams)
		{
			Type type = Assembly.Load(assamblyName).GetType(className);

			ConstructorInfo constructor = type.GetConstructor(GetCtorParametersTypes(inputParams));

			if (constructor != null)
			{
				object result = constructor.Invoke(inputParams);

				return result;
			}

			return null;
		}

		private static Type[] GetCtorParametersTypes(object[] inputParams)
		{
			List<Type> constructorsParameters = new List<Type>();

			foreach (var p in inputParams)
			{
				constructorsParameters.Add(p.GetType());
			}

			return constructorsParameters.ToArray();
		}
	}
}
