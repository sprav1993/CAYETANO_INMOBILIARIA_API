﻿using System;
using System.Data.SqlClient;
using AutoMapper;
using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Application.Interface;
using Cayetano.Inmobiliaria.Domain.Interface;
using Cayetano.Inmobiliaria.Transversal.Common;

namespace Cayetano.Inmobiliaria.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
        }
        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacios.";
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
