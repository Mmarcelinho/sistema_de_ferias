// Controller

global using Microsoft.AspNetCore.Mvc;
global using System.Net;

// Main

global using SistemaDeFerias.Application;
global using SistemaDeFerias.Application.Servicos.AutoMapper;
global using SistemaDeFerias.Infrastructure;

// Setor

global using SistemaDeFerias.Application.UseCases.Setor.Registrar;
global using SistemaDeFerias.Application.UseCases.Setor.Atualizar;
global using SistemaDeFerias.Application.UseCases.Setor.Deletar;
global using SistemaDeFerias.Application.UseCases.Setor.RecuperarPorId;
global using SistemaDeFerias.Comunicacao.Requisicoes.Setor;
global using SistemaDeFerias.Comunicacao.Respostas.Setor;

// Departamento

global using SistemaDeFerias.Application.UseCases.Departamento.Registrar;
global using SistemaDeFerias.Application.UseCases.Departamento.Atualizar;
global using SistemaDeFerias.Application.UseCases.Departamento.Deletar;
global using SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorId;
global using SistemaDeFerias.Comunicacao.Requisicoes.Departamento;
global using SistemaDeFerias.Comunicacao.Respostas.Departamento;

// Admin

global using SistemaDeFerias.Domain.Repositorios.Admin;
global using SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;
global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;
global using SistemaDeFerias.Application.UseCases.Usuario.Admin.AlterarSenha;
global using SistemaDeFerias.Application.UseCases.Usuario.Admin.RecuperarPerfil;
global using SistemaDeFerias.Application.UseCases.Dashboard.Admin.PedidosAdmin;
global using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
global using SistemaDeFerias.Comunicacao.Respostas.Admin;


// Funcionario

global using SistemaDeFerias.Domain.Repositorios.Funcionario;
global using SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;
global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;
global using SistemaDeFerias.Application.UseCases.Usuario.Funcionario.AlterarSenha;
global using SistemaDeFerias.Application.UseCases.Usuario.Funcionario.RecuperarPerfil;
global using SistemaDeFerias.Application.UseCases.Dashboard.Funcionario.PedidosFuncionario;
global using SistemaDeFerias.Comunicacao.Requisicoes;
global using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
global using SistemaDeFerias.Comunicacao.Respostas.Funcionario;


// PedidoFerias

global using SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;
global using SistemaDeFerias.Application.UseCases.PedidoFerias.RecuperarPorId;
global using SistemaDeFerias.Application.UseCases.PedidoFerias.Atualizar;
global using SistemaDeFerias.Application.UseCases.PedidoFerias.Deletar;
global using SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;
global using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;
global using SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

// Filtros

global using SistemaDeFerias.Api.Filtros;

// Filtros/UsuarioLogado

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.IdentityModel.Tokens;
global using SistemaDeFerias.Application.Servicos.Token;
global using SistemaDeFerias.Comunicacao.Respostas;
global using SistemaDeFerias.Exceptions;
global using SistemaDeFerias.Exceptions.ExceptionsBase;
global using SistemaDeFerias.Api.Filtros.UsuarioLogado;






