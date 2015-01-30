using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Repository;
using AutoMapper;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Service
{
	public class AccountService :BaseService , IAccountService
	{
		IBaseRepository<UserInfo> _userInfoRepository;
		INotifyRepository _notifyRepository;
		ICacheProvider _cacheProvider;

		public AccountService (IBaseRepository<UserInfo> userInfoRepository, INotifyRepository notifyRepository, ICacheProvider cacheProvider)
		{
			_userInfoRepository = userInfoRepository;
			_notifyRepository = notifyRepository;
			_cacheProvider = cacheProvider;
		}

		public RegisterResponse Register (RegisterRequest request)
		{
			var userInfo = Mapper.Map<UserInfo> (request);

			var id = _userInfoRepository.Insert (userInfo);

			if (id > 0) {
				userInfo.Id = id;

				var token = Guid.NewGuid ().ToString ();

				var notify = _notifyRepository.GetUserNotify (userInfo);
				//存储session
				_cacheProvider.Set (token, userInfo);

				return Success (new RegisterResponse {
						Token = token, 
						Notify = notify != null ? notify.Content : string.Empty 
					});
			}

			return Fail<RegisterResponse> ("unknowError");
		}

		public LoginResponse Login (LoginRequest request)
		{
			throw new NotImplementedException ();
		}
	}
}

