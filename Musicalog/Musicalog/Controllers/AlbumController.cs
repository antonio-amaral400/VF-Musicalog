using Musicalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musicalog.Controllers
{
    public class AlbumController : Controller
    {
        public ActionResult List(string orderby = "id-a", int page = 1)
        {
            var viewModel = new AlbumListViewModel(orderby, page);
            viewModel.Load();
            return View(viewModel);
        }

        public ActionResult InsertOrUpdate(int? id = null)
        {
            var viewModel = new AlbumViewModel(id);
            viewModel.Prepare();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertOrUpdate(AlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Prepare();
                return View(model);
            }
            model.Save();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Musicalog.Service.ServiceClient svc = new Musicalog.Service.ServiceClient();
            svc.Delete(id);
            return RedirectToAction("List");
        }
    }
}