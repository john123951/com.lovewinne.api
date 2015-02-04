using System;
using Sweet.LoveWinne.Infrastructure;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Repository;
using Sweet.LoveWinne.Utility;
using AutoMapper;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Service
{
	public class ShadowServerService : DefaultService, IShadowServerService
	{
		IShadowServerRepository _shadowServerRepository;

		public ShadowServerService (IShadowServerRepository shadowServerRepository)
		{
			_shadowServerRepository = shadowServerRepository;
		}

		public ServicesResult<List<ServerDto>> GetServerList (long userId)
		{
			var serverList = _shadowServerRepository.GetServerListByUserId (userId);

			if (serverList.IsNotEmpty ()) {
				var dtoList = Mapper.Map<List<ServerDto>> (serverList);

				return Success (dtoList);
			}

			return Fail<List<ServerDto>> ((int)ApiStatusCode.ShadowServer.GetServerListFailed);
		}
	}
}

