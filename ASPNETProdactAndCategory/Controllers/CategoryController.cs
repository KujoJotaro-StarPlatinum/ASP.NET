using Microsoft.AspNetCore.Mvc;
using ASPNETProdactAndCategory.Models;
using ASPNETProdactAndCategory.Context;

namespace ASPNETProdactAndCategory.Controllers
{ 
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
{
        private readonly AppDbContext _categoryContext;

        public CategoryController(AppDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] Category category)
        {
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult<bool> UpdateCategory([FromQuery] int id, [FromBody] Category category)
        {
            var result = _categoryContext.Categories.Find(id);
            if (result != null)
            {
                result.Id = category.Id;
                result.Name = category.Name;
                _categoryContext.Categories.Update(result);
                _categoryContext.SaveChanges();
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
            var result = _categoryContext.Categories.Find(id);
            if (result != null)
            {
                _categoryContext.Categories.Remove(result);
                _categoryContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}