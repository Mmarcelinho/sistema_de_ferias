//Bootstrapper

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using SistemaDeFerias.Application.Servicos.Criptografia;
global using SistemaDeFerias.Application.Servicos.Token;
global using SistemaDeFerias.Application.Servicos.UsuarioLogado.Admin;
global using SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;
global using SistemaDeFerias.Application.UseCases.Setor.Registrar;

// Map

global using AutoMapper;
global using HashidsNet;

//Exceptions

global using FluentValidation;
global using SistemaDeFerias.Exceptions;
global using SistemaDeFerias.Exceptions.ExceptionsBase;

// servicos

// Criptografia

global using System.Security.Cryptography;
global using System.Text;

// Token

global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;

// UsuarioLogado

global using Microsoft.AspNetCore.Http;
global using SistemaDeFerias.Domain.Repositorios.Admin;
global using SistemaDeFerias.Domain.Repositorios.Funcionario;


// SetorUseCases

global using SistemaDeFerias.Domain.Repositorios;
global using SistemaDeFerias.Domain.Repositorios.Setor;
global using SistemaDeFerias.Comunicacao.Requisicoes.Setor;
global using SistemaDeFerias.Comunicacao.Respostas.Setor;

