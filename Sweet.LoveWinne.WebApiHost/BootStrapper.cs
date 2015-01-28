using System;
using AutoMapper;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.WebApiHost
{
	public static class BootStrapper
	{
		public static void Configure ()
		{
			ConfigureDependencies ();
			ConfigureMapping ();
		}

		private static void ConfigureDependencies ()
		{
		}

		private static void ConfigureMapping ()
		{
			Mapper.CreateMap<UserInfo, UserInfoDto> ();
			Mapper.CreateMap<UserInfoDto, UserInfo> ();

			Mapper.AssertConfigurationIsValid ();
		}
	}
}

