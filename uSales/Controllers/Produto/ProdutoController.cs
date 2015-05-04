using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using uSales.Models.Repository;


namespace uSales.Controllers.Produto
{
    public class ProdutoController : Controller
    {
        private IRepository<Models.Produto.Produto> produtoRepository;

        public ProdutoController()
        {
            this.produtoRepository = new ProdutoRepository(new Models.SalesContext());
        }

        // GET: Produto
        public ActionResult Index()
        {
            //var produtos = from produto in produtoRepository.Listar()
            //               select produto;
            return View(produtoRepository.Listar());
        }

        public ActionResult Detalhes(int? id)
        {
            if(id == null || id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }
            Models.Produto.Produto produto = produtoRepository.Detalhes(id);
            return View(produto);
        }

        public ActionResult Novo()
        {
            return View(new Models.Produto.Produto());
        }

        [HttpPost]
        public ActionResult Novo(Models.Produto.Produto produto)
        {
            try
            {
                if(produto == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
                }

                if(ModelState.IsValid)
                {
                    produtoRepository.Novo(produto);
                    produtoRepository.Salvar();
                    return RedirectToAction("Index");
                }
            } catch(DataException)
            {
                ModelState.AddModelError("", "Não foi possível realizar a ação.");
            }
            return View(produto);
        }

        public ActionResult Editar(int id)
        {
            return View();
        }

        public ActionResult Editar(int id, Models.Produto.Produto produto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    produtoRepository.Editar(produto);
                    produtoRepository.Salvar();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não foi possível realizar a ação.");
            }
            return View(produto);
        }

        public ActionResult Apagar(int? id, bool? saveChangesError)
        {
            if(id == null || id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }
            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não foi possível realizar a ação.";
            }
            Models.Produto.Produto produto = produtoRepository.Detalhes(id);
            return View(produto);
        }

        [HttpPost, ActionName("Apagar")]
        public ActionResult Apagar(int? id)
        {
            try {
                if (id < 0 || id == null )
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
                }

                Models.Produto.Produto produto = produtoRepository.Detalhes(id);
                produtoRepository.Apagar(id);
                produtoRepository.Salvar();
            }
            catch (DataException)
            {
                return RedirectToAction("Apagar", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}