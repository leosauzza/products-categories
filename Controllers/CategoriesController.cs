using Microsoft.AspNetCore.Mvc;
using products_categories.Application;
using products_categories.Domain.Models;

namespace products_categories.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Category category, CancellationToken cancellationToken)
    {
        await _categoryService.AddAsync(category, cancellationToken);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Category category, CancellationToken cancellationToken)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }
        await _categoryService.UpdateAsync(category, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}

