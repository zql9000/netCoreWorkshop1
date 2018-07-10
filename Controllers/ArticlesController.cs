using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Article.DataSource);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Id = (Article.DataSource.Count > 0)?Article.DataSource.Last().Id + 1 : 1;
                Article.DataSource.Add(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var articulo = Article.DataSource.FirstOrDefault(x => x.Id == id);

            return View(articulo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var articulo = Article.DataSource.FirstOrDefault(x => x.Id == id);
            Article.DataSource.Remove(articulo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var articulo = Article.DataSource.FirstOrDefault(x => x.Id == id);

            return View(articulo);
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                var articulo = Article.DataSource.FirstOrDefault(x => x.Id == article.Id);
                articulo.Title = article.Title;
                return RedirectToAction("Index");
            }

            return View(article);
        }
    }
}
