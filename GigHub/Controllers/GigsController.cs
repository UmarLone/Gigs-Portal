using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {

        private readonly ApplicationDbContext _dbcontext;


        public GigsController()
        {
            _dbcontext = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Create()
        {


            var viewModel = new GigFormViewModel
            {


                Genres = _dbcontext.Genres.ToList()

            };

            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                viewModel.Genres = _dbcontext.Genres.ToList();
                return View("Create", viewModel);


            }

            var gig = new Gig
            {

                ArtistId = User.Identity.GetUserId(),
                DataTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue



            };

            _dbcontext.Gigs.Add(gig);

            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");

        }



    }
}