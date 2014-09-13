using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using AutoMapper;

using Common.DataAccess;
using Website.Extensions;
using Website.Models;
using Website.Models.Auctions;

namespace Website.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly IAuctionRepository _repository;

        public AuctionsController(IAuctionRepository repository)
        {
            _repository = repository;
        }

        protected internal string CurrentUsername
        {
            get { return _currentUsername ?? User.Identity.Name; }
            set { _currentUsername = value; }
        }
        private string _currentUsername;

        [Authorize]
        [HttpPost, Route("auctions/{id}/bids")]
        public ActionResult Bid(long id, decimal amount)
        {
            var auction = _repository.Find(id);

            if (auction == null)
                return HttpNotFound("Auction not found");

            if(auction.CurrentPrice >= amount)
            {
                TempData.ErrorMessage(
                        "Your bid of {0:c} isn't higher than the current bid ({1:c}). Try again!",
                        amount, auction.CurrentPrice);

                return RedirectToAction("Details", new { id = auction.Id });
            }

            auction.PlaceBid(CurrentUsername, amount);
            _repository.SaveChanges();

            TempData.SuccessMessage(
                "Congratulations - you're the highest bidder at {0:c}!", 
                auction.CurrentPrice);

            return RedirectToAction("Details", new {id});
        }

        [Route("auctions/{id}")]
        public ActionResult Details(int id)
        {
            var auction = _repository.Find(id);

            if (auction == null)
                return HttpNotFound("Auction not found");

            var viewModel = Mapper.DynamicMap<AuctionViewModel>(auction);
            viewModel.SellerIsCurrentUser = User.Identity.Name == viewModel.SellerUsername;
            
            return View("Details", viewModel);
        }

        [Route("auctions/{id}/history")]
        public ActionResult History(int id)
        {
            return View("History");
        }
    }
}