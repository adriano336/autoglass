using AutoGProd.Business.Business;
using AutoGProd.Business.Dto;
using AutoGProd.Domain.Business;
using AutoGProd.Domain.Entity;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS.Utils;

namespace AutoGProd.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoBusiness produtoBusiness;
        private readonly IFornecedorBusiness fornecedorBusiness;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoBusiness produtoBusiness, IMapper mapper, IFornecedorBusiness fornecedorBusiness)
        {
            this.produtoBusiness = produtoBusiness;

            _mapper = mapper;
            this.fornecedorBusiness = fornecedorBusiness;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FiltroProdutoDto filtro)
        {
            var pagedSearchDTO = await produtoBusiness.EncontrarFiltro(filtro);

            return Ok(pagedSearchDTO);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await produtoBusiness.FindById(id);
            var fornecedor = await fornecedorBusiness.FindAll();

            var form = new FormProdutoDto();
            form.Produto = _mapper.Map<ProdutoDto>(produto);
            form.Fornecedores = _mapper.Map<IList<FornecedorDto>>(fornecedor);

            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            var prodNew = await produtoBusiness.Create(produto);

            if (produtoBusiness.PossuiErros)
            {
                return BadRequest(produtoBusiness.MensagemErro);
            }

            return CreatedAtAction(nameof(Get), prodNew, new { prodNew.Id });
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoDto produtoDto)
        {            
            var produto = await produtoBusiness.Update(_mapper.Map<Produto>(produtoDto));

            if (produtoBusiness.PossuiErros)
            {
                return BadRequest(produtoBusiness.MensagemErro);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await produtoBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("fornecedores")]
        public async Task<IActionResult> ObterFornecedores(int id)
        {
            var fornecedor = await fornecedorBusiness.FindAll();
            return Ok(_mapper.Map<IList<FornecedorDto>>(fornecedor));
        }
    }
}
