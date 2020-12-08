using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Pagination;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetCategoriasProdutos();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);

            return categoriasDto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get([FromQuery] CategoriasParameters categoriasParameters)
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetCategorias(categoriasParameters);

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);

            return categoriasDto;
        }

        /// <summary>
        /// Obtem uma categoria pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objetos Categoria</returns>
        [HttpGet("{id}", Name = "ObterCategoria")]
        [ProducesResponseType(typeof(CategoriaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _unitOfWork.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return categoriaDto;
        }

        /// <summary>
        /// Inclui uma nova Categoria
        /// </summary>
        /// <remarks>
        /// Exemplo de request  :
        /// 
        ///     POST api/categorias
        ///     {
        ///         "categoriaId" : 1,
        ///         "nome": "categoria 1",
        ///         "imagemURL": "http://teste.net/1.jpg"
        ///     }
        /// </remarks>
        /// <param name="categoriaDto">Objeto Categoria</param>
        /// <returns>Objeto Categoria incluído</returns>
        /// <remarks>Retorna um Objeto Categoria incluído</remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _unitOfWork.CategoriaRepository.Add(categoria);
            await _unitOfWork.Commit();

            var  categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId, categoriaDTO });
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                return BadRequest();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _unitOfWork.CategoriaRepository.Update(categoria);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _unitOfWork.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            
            _unitOfWork.CategoriaRepository.Delete(categoria);
            await _unitOfWork.Commit();
            
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return categoriaDto;
        }
    }
}
