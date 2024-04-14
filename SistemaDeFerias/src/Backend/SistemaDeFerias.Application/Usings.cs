//Bootstrapper

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using SistemaDeFerias.Application.Servicos.Criptografia;
global using SistemaDeFerias.Application.Servicos.Token;
global using SistemaDeFerias.Application.Servicos.UsuarioLogado.Admin;
global using SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;

// Map

global using AutoMapper;

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
global using SistemaDeFerias.Application.UseCases.Setor.Registrar;
global using SistemaDeFerias.Application.UseCases.Setor.Atualizar;
global using SistemaDeFerias.Application.UseCases.Setor.Deletar;
global using SistemaDeFerias.Application.UseCases.Setor.RecuperarPorId;

// DepartamentoUseCases

global using SistemaDeFerias.Domain.Repositorios.Departamento;
global using SistemaDeFerias.Comunicacao.Requisicoes.Departamento;
global using SistemaDeFerias.Comunicacao.Respostas.Departamento;
global using SistemaDeFerias.Application.UseCases.Departamento.Registrar;
global using SistemaDeFerias.Application.UseCases.Departamento.Atualizar;
global using SistemaDeFerias.Application.UseCases.Departamento.Deletar;
global using SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorId;

// AdminUseCases

global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;
global using SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;
global using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
global using SistemaDeFerias.Comunicacao.Respostas.Admin;
global using System.Text.RegularExpressions;

// FuncionarioUseCases

global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;
global using SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;
global using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
global using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

// PedidoFeriasUseCases

global using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;
global using SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;
global using SistemaDeFerias.Domain.Repositorios.PedidoFerias;
global using SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;

// Usuario





