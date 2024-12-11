﻿

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_pollService.GetAll());
    }



    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var poll = _pollService.GetPoll(id);
        return poll is null ? NotFound() : Ok(poll);
    }

    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
        var newPoll = _pollService.Add(request);
        return CreatedAtAction(nameof(Get), new { id = newPoll.Id} , newPoll);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Poll request) 
    {
         var isUpdated = _pollService.Update(id, request);

         if(!isUpdated)
            return NotFound();

         return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDelete = _pollService.Delete(id);

        if (!isDelete)
            return NotFound();

        return NoContent();
    }
}
