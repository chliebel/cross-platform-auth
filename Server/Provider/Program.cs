using System;
using Microsoft.Owin.Hosting;

namespace Provider
{
	class Program
	{
		static void Main(string[] args)
		{
			using (WebApp.Start<Startup>("http://+:8081"))
			{
				Console.WriteLine("IdentityServer running...");
				Console.ReadLine();
			}
		}
	}
}
