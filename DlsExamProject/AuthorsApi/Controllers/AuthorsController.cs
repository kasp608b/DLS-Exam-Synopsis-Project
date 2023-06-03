using AuthorsApi.Models;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorDatabaseService _authorService;
        private readonly IConverter<Author, AuthorDto> _authorConverter;
        private readonly BooksServiceGateway _booksServiceGateway;

        public AuthorsController(AuthorDatabaseService authorService, IConverter<Author, AuthorDto> authorConverter, BooksServiceGateway booksServiceGateway)
        {
            _authorService = authorService;
            _authorConverter = authorConverter;
            _booksServiceGateway = booksServiceGateway;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> Get()
        {
            Console.WriteLine("Get authors called");
            try
            {
                var authorList = await _authorService.GetAsync();

                var authorDtoList = authorList.Select(x => _authorConverter.Convert(x)).ToList();

                return new ObjectResult(authorDtoList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }

        }

        // GET api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(string id)
        {
            try
            {
                var author = await _authorService.GetAsync(id);

                if (author is null)
                {
                    return NotFound();
                }

                var authorDto = _authorConverter.Convert(author);

                var booksByAuthor = await _booksServiceGateway.GetBooksByAuthor(id);

                if (booksByAuthor.Any())
                {
                    authorDto.Books = booksByAuthor;
                }

                return authorDto;

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }

        }

        // POST api/Authors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDto newAuthorDto)
        {
            try
            {
                var newAuthor = _authorConverter.Convert(newAuthorDto);

                var author = await _authorService.CreateAsync(newAuthor);

                return CreatedAtAction(nameof(Get), new { id = author._id }, author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }
        }

        // PUT api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] AuthorDto updatedAuthorDto)
        {
            try
            {
                var author = await _authorService.GetAsync(id);

                if (author is null)
                {
                    return NotFound();
                }

                var updatedBook = _authorConverter.Convert(updatedAuthorDto);

                updatedBook._id = author._id;

                await _authorService.UpdateAsync(id, updatedBook);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }
        }

        // DELETE api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var author = await _authorService.GetAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            await _authorService.RemoveAsync(id);

            return NoContent();
        }
    }
}
