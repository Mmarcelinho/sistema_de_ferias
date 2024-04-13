// Controller

global using Microsoft.AspNetCore.Mvc;

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

global using SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;
global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;
global using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
global using SistemaDeFerias.Comunicacao.Respostas.Admin;


// Funcionario

global using SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;
global using SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;
global using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
global using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

