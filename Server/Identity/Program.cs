using System;
using Microsoft.Owin.Hosting;

namespace Identity
{
	class Program
	{
		static void Main(string[] args)
		{
			using (WebApp.Start<Startup>("http://+:8080"))
			{
				Console.WriteLine("IdentityServer running...");
				Console.ReadLine();
			}
		}
	}
}
