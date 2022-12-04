using AndreGutierrez.API;
using AndreGutierrez.API.Common;
using AndreGutierrez.Application.Cidades.Commands;
using AndreGutierrez.Application.Cidades.Dtos;
using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Application.UFs.Queries;
using AndreGutierrez.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AndreGutierrez.API.Controllers;

[Route("api/cidades")]
[ApiController]
public class CidadeController : BaseController
{
    private readonly IMediator _mediator;

    public CidadeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseList<CidadeDto>>> Get()
    {
        try
        {
            var cidades = await _mediator.Send(new ListaCidadesQuery());
            return Ok(new ResponseList<CidadeDto>(cidades));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpGet("{cidadeId}")]
    public async Task<ActionResult<ResponseObject<CidadeDto>>> Get(int cidadeId)
    {
        try
        {
            var cidade = await _mediator.Send(new ObterCidadeQuery(cidadeId));
            return Ok(new ResponseObject<CidadeDto>(cidade));
        }
        catch(BusinessValidationException ex)
        {
            return BadRequest(new ResponseBase(ex));
        }
        catch(NotFoundCommandException ex)
        {
            return NotFound(new ResponseBase(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ResponseObject<CidadeDto>>> Post([FromBody] CriacaoCidadeRequest request)
    {
        try
        {
            var command = (CriacaoCidadeCommand)request;
            var cidade = await _mediator.Send(command);
            return Created("/api/cidades/" + cidade.Id, new ResponseObject<CidadeDto>(cidade));
        }
        catch(BusinessValidationException ex)
        {
            return BadRequest(new ResponseObject<CidadeDto>(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpPut("{cidadeId}")]
    public async Task<ActionResult<ResponseBase>> Put(int cidadeId, [FromBody] AlteracaoCidadeRequest request)
    {
        try
        {
            var command = (AlteracaoCidadeCommand)request;
            command.CidadeId = cidadeId;
            var cidade = await _mediator.Send(command);
            return Ok(new ResponseBase());
        }
        catch(BusinessValidationException ex)
        {
            return BadRequest(new ResponseObject<CidadeDto>(ex));
        }
        catch(NotFoundCommandException ex)
        {
            return NotFound(new ResponseObject<CidadeDto>(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpDelete("{cidadeId}")]
    public async Task<ActionResult<ResponseBase>> Delete(int cidadeId)
    {
        try
        {
            var command = new ExclusaoCidadeCommand(cidadeId);
            var cidade = await _mediator.Send(command);
            return Ok(new ResponseBase());
        }
        catch(BusinessValidationException ex)
        {
            return BadRequest(new ResponseObject<CidadeDto>(ex));
        }
        catch(NotFoundCommandException ex)
        {
            return NotFound(new ResponseObject<CidadeDto>(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }
}