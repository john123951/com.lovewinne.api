using System;
using AutoMapper;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public class MappingManager
	{
		public static void ConfigureMapping ()
		{
			Mapper.CreateMap<UserInfo, UserInfoDto> ();
			Mapper.CreateMap<UserInfoDto, UserInfo> ();

			Mapper.AssertConfigurationIsValid ();
		}
	}
}

