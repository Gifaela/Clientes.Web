using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel; // <- necessário para capturar FaultException
using Clientes.Web.ClientesWcReference;
using Clientes.Web.Models;

namespace Clientes.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteServiceClient _service;

        public ClientesController()
        {
            _service = new ClienteServiceClient();
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            var clientes = await _service.ListarClientesAsync();

            var viewModels = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Cpf = c.Cpf,
                DataNascimento = c.DataNascimento,
                Sexo = c.Sexo,
                IdSituacao = c.IdSituacao,
                NomeSituacao = c.NomeSituacao
            }).ToList();

            return View(viewModels);
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(400, "Id obrigatório");

            var cliente = await _service.ObterClienteAsync(id.Value);
            if (cliente == null) return HttpNotFound();

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                IdSituacao = cliente.IdSituacao,
                NomeSituacao = cliente.NomeSituacao
            };

            return View(viewModel);
        }

        // GET: Clientes/Create
        public async Task<ActionResult> Create()
        {
            var situacoes = await _service.ListarSituacoesAsync();
            ViewBag.Situacoes = situacoes;
            return View();
        }

        // POST: Clientes/Create
        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteViewModel clienteVM)
        {
            if (!ModelState.IsValid)
            {
                var situacoes = await _service.ListarSituacoesAsync();
                ViewBag.Situacoes = situacoes;
                return View(clienteVM);
            }

            try
            {
                var cliente = new ClienteModel
                {
                    Id = clienteVM.Id,
                    Nome = clienteVM.Nome,
                    Cpf = clienteVM.Cpf,
                    DataNascimento = clienteVM.DataNascimento,
                    Sexo = clienteVM.Sexo,
                    IdSituacao = clienteVM.IdSituacao
                };

                await _service.CriarClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (FaultException ex)
            {
                if (ex.Message.Contains("CPF"))
                {
                    ModelState.AddModelError("Cpf", ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao cadastrar cliente: " + ex.Message);
                }

                var situacoes = await _service.ListarSituacoesAsync();
                ViewBag.Situacoes = situacoes;

                return View(clienteVM);
            }

        }



        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(400, "Id obrigatório");

            var cliente = await _service.ObterClienteAsync(id.Value);
            if (cliente == null) return HttpNotFound();

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                IdSituacao = cliente.IdSituacao,
                NomeSituacao = cliente.NomeSituacao
            };

            var situacoes = await _service.ListarSituacoesAsync();
            ViewBag.Situacoes = situacoes;

            return View(viewModel);
        }

        // POST: Clientes/Edit/5
        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClienteViewModel clienteVM)
        {
            if (!ModelState.IsValid)
            {
                var situacoes = await _service.ListarSituacoesAsync();
                ViewBag.Situacoes = situacoes;
                return View(clienteVM);
            }

            try
            {
                var cliente = new ClienteModel
                {
                    Id = clienteVM.Id,
                    Nome = clienteVM.Nome,
                    Cpf = clienteVM.Cpf,
                    DataNascimento = clienteVM.DataNascimento,
                    Sexo = clienteVM.Sexo,
                    IdSituacao = clienteVM.IdSituacao
                };

                await _service.AtualizarClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (FaultException ex)
            {
                if (ex.Message.Contains("CPF"))
                {
                    ModelState.AddModelError("Cpf", ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao cadastrar cliente: " + ex.Message);
                }

                var situacoes = await _service.ListarSituacoesAsync();
                ViewBag.Situacoes = situacoes;

                return View(clienteVM);
            }

        }



        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(400, "Id obrigatório");

            var cliente = await _service.ObterClienteAsync(id.Value);
            if (cliente == null) return HttpNotFound();

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                IdSituacao = cliente.IdSituacao,
                NomeSituacao = cliente.NomeSituacao
            };

            return View(viewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _service.ExcluirClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
