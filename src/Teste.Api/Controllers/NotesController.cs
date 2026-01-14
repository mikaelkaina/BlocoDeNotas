using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Teste.Application.DTOs.Notes;
using Teste.Application.Interfaces;

namespace Teste.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    private string? GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteDto dto)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var result = await _noteService.CreateAsync(userId, dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetMyNotes()
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var result = await _noteService.GetByUserAsync(userId);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateNoteDto dto)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var success = await _noteService.UpdateAsync(userId, id, dto);
        if (!success)
            return NotFound(new { message = "Nota não encontrada." });

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var success = await _noteService.DeleteAsync(userId, id);
        if (!success)
            return NotFound(new { message = "Nota não encontrada." });

        return NoContent();
    }
}