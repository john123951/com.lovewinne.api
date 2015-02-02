﻿using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Repository;
using AutoMapper;
using Sweet.LoveWinne.Infrastructure;
using System.Linq;

namespace Sweet.LoveWinne.Service
{
	public class AccountService :DefaultService , IAccountService
	{
		IRepository<UserInfo> _userInfoRepository;
		INotifyRepository _notifyRepository;
		ICacheProvider _cacheProvider;

		public AccountService (IRepository<UserInfo> userInfoRepository, INotifyRepository notifyRepository, ICacheProvider cacheProvider)
		{
			_userInfoRepository = userInfoRepository;
			_notifyRepository = notifyRepository;
			_cacheProvider = cacheProvider;
		}

		public ServicesResult<UserInfo> Register (RegisterParameter parameter)
		{
			var userInfo = new UserInfo {
				UserName = parameter.UserName, 
				Password = parameter.Password,
				CreateDate = DateTime.Now, 
				IsValid = true
			};

			var id = _userInfoRepository.Insert (userInfo);

			if (id > 0) {
				userInfo.Id = id;

				return	Success (userInfo);
			}

			return Fail<UserInfo> ((int)ApiStatusCode.Account.RegisterFailed);
		}

		public ServicesResult<LoginModel> Login (LoginParameter parameter)
		{
			var userInfo = _userInfoRepository.LoadEntities (x => x.IsValid && x.UserName == parameter.UserName && x.Password == parameter.Password).FirstOrDefault ();

			if (userInfo != null && userInfo.Id > 0) {

				var token = Guid.NewGuid ().ToString ();

				var notify = _notifyRepository.GetUserNotify (userInfo);

				var result = new LoginModel { 
					UserInfo = userInfo, 
					AccessToken = token, 
					Notify = notify.Content
				};

				return Success (result);
			}


			return Fail<LoginModel> ((int)ApiStatusCode.Account.InvalidUserNameOrPassword);
		}
	}
}

