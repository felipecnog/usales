using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSales.Models.Produto;
using uSales.Models.Repository;

namespace uSales.Controllers.Produto
{
    public class MedidaController : Controller
    {
        private IRepository<Medida> medidaRepository;
        public MedidaController()
        {
            this.medidaRepository = new MedidaRepository(new Models.SalesContext());
        }
        // GET: Medida
        public ActionResult Index()
        {
            return View();
        }
    }
}