using AndreGutierrez.API;
using AndreGutierrez.API.Common;
using AndreGutierrez.Application.Common.Validation;
using AndreGutierrez.Application.Pessoas.Commands;
using AndreGutierrez.Application.Pessoas.Dtos;
using AndreGutierrez.Application.Pessoas.Queries;
using AndreGutierrez.Application.UFs.Queries;
using AndreGutierrez.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AndreGutierrez.API.Controllers;

[Route("api/pessoas")]
[ApiController]
public class PessoaController : BaseController
{
    private readonly IMediator _mediator;

    public PessoaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var pessoas = await _mediator.Send(new ListaPessoasQuery());
            return Ok(new ResponseList<PessoaDto>(pessoas));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpGet("{pessoaId}")]
    public async Task<IActionResult> Get(int pessoaId)
    {
        try
        {
            var pessoa = await _mediator.Send(new ObterPessoaQuery(pessoaId));
            return Ok(new ResponseObject<PessoaDto>(pessoa));
        }
        catch(NotFoundCommandException ex)
        {
            return NotFound(new ResponseObject<PessoaDto>(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriacaoPessoaRequest request)
    {
        try
        {
            var command = (CriacaoPessoaCommand)request;
            var pessoa = await _mediator.Send(command);
            return Created("/api/pessoas/" + pessoa.Id, new ResponseObject<PessoaDto>(pessoa));
        }
        catch(BusinessValidationException ex)
        {
            return BadRequest(new ResponseObject<PessoaDto>(ex));
        }
        catch(NotFoundCommandException ex)
        {
            return NotFound(new ResponseObject<PessoaDto>(ex));
        }
        catch(Exception ex)
        {
            return ExceptionHandling(ex);
        }
    }

    [HttpPut("{pessoaId}")]
    public async Task<IActionResult> Put(int pessoaId, [FromBody] AlteracaoPessoaRequest request)
    {
        try
        {
            var command = (AlteracaoPessoaCommand)request;
            command.PessoaId = pessoaId;
            var pessoa = await _mediator.Send(command);
            return Ok(new ResponseBase());
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

    [HttpDelete("{pessoaId}")]
    public async Task<IActionResult> Delete(int pessoaId)
    {
        try
        {
            var command = new ExclusaoPessoaCommand(pessoaId);
            var pessoa = await _mediator.Send(command);
            return Ok(new ResponseBase());
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
}