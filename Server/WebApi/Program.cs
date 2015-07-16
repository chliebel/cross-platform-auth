using System;
using Microsoft.Owin.Hosting;

namespace WebApi
{
	class Program
	{
		static void Main(string[] args)
		{
			using (WebApp.Start<Startup>("http://+:8082"))
			{
				Console.WriteLine("Web API running...");
				Console.ReadLine();
			}
		}
	}
}
