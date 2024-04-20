using Microsoft.AspNetCore.Mvc;
using ASPNETProdactAndCategory.Models;
using ASPNETProdactAndCategory.Context;

namespace ASPNETProdactAndCategory.Controllers
{ 
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ProdactController : ControllerBase
    {
        private readonly AppDbContext _prodactContext;

        public ProdactController(AppDbContext prodactContext)
        {
            _prodactContext = prodactContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prodact>> Prodacts()
        {
            var prodacts = _prodactContext.Prodacts;
            return Ok(prodacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Prodact> GetProdact(int id)
        {
            var prodacts = _prodactContext.Prodacts.Find(id);
            if (prodacts != null)
                return Ok(prodacts);
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<Prodact> GetProdactWithParam([FromQuery] int id)
        {
            var prodacts = _prodactContext.Prodacts.Find(id);
            if (prodacts != null)
                return Ok(prodacts);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult AddProdact([FromBody] Prodact prodact)
        {
            _prodactContext.Prodacts.Add(prodact);
            _prodactContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAction()
        {
            return RedirectToAction(nameof(Prodacts));
        }

        [HttpPut]
        public ActionResult<bool> UpdateStudent([FromQuery] int id, [FromBody] Prodact prodact)
        {
            var result = _prodactContext.Prodacts.Find(id);
            if (result != null)
            {
                result.Name = prodact.Name;
                result.Price = prodact.Price;
                result.Count = prodact.Count;
                result.Id = prodact.Id;
                _prodactContext.Prodacts.Update(result);
                _prodactContext.SaveChanges();
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _prodactContext.Prodacts.Find(id);
            if (result != null)
            {
                _prodactContext.Prodacts.Remove(result);
                _prodactContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Prodact>> GetProdacts([FromQuery] string name = null, [FromQuery] string count = null,
                [FromQuery] int page = 1, [FromQuery] int pageSize = 4)
        {
            var prodacts = _prodactContext.Prodacts.OrderBy(s => s.Count).ToList();
            if (name != null)
            {
                prodacts = prodacts.Where(x => x.Name.Equals(name)).ToList();
            }
            if (count != null && count.Contains("desc"))
            {
                prodacts = prodacts.OrderByDescending(prodacts => prodacts.Count).ToList();
            }

            var totalCount = prodacts.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            prodacts = prodacts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Prodacts = prodacts
            };
            return Ok(result);
        }
    }
}