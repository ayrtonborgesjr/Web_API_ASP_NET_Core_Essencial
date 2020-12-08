using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Pagination;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("menorpreco")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPorPreco()
        {
            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosPorPreco();
            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

            return produtosDto;
        }

        /// <summary>
        /// Exibe uma relação de Produtos
        /// </summary>
        /// <param name="produtosParameters"></param>
        /// <returns>Retorna uma lista de objetos Produto</returns>
        // api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get([FromQuery] ProdutosParameters produtosParameters)
        {
            var produtos = await _unitOfWork.ProdutoRepository.GetProdutos(produtosParameters);

            var metadata = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

            return produtosDto;
        }

        /// <summary>
        /// Obtem um produto pelo Identificador produtoId
        /// </summary>
        /// <param name="id">Código do Produto</param>
        /// <returns>Um objeto Produto</returns>
        [HttpGet("{id}", Name = "ObterProduto")]
        [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _unitOfWork.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return produtoDto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            _unitOfWork.ProdutoRepository.Add(produto);
            await _unitOfWork.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId, produtoDTO });
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            _unitOfWork.ProdutoRepository.Update(produto);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produto = await _unitOfWork.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            
            _unitOfWork.ProdutoRepository.Delete(produto);
            await _unitOfWork.Commit();

            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return produtoDto;
        }
    }
}
