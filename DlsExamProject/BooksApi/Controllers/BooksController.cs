﻿using BooksApi.Models;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDatabaseService _bookService;
        private readonly IConverter<Book, BookDto> _bookConverter;

        public BooksController(BookDatabaseService bookService, IConverter<Book, BookDto> bookconverter)
        {
            _bookService = bookService;
            _bookConverter = bookconverter;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            try
            {
                var bookList = await _bookService.GetAsync();

                var bookDtoList = bookList.Select(x => _bookConverter.Convert(x)).ToList();

                return new ObjectResult(bookDtoList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }

        }


        // GET api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(string id)
        {
            try
            {
                var book = await _bookService.GetAsync(id);

                if (book is null)
                {
                    return NotFound();
                }

                var bookDto = _bookConverter.Convert(book);

                return bookDto;

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }

        }

        // POST api/Books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto newBookDto)
        {
            try
            {
                var newBook = _bookConverter.Convert(newBookDto);

                var book = await _bookService.CreateAsync(newBook);

                return CreatedAtAction(nameof(Get), new { id = book._id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }
        }

        // PUT api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BookDto updatedBookDto)
        {
            try
            {
                var book = await _bookService.GetAsync(id);

                if (book is null)
                {
                    return NotFound();
                }

                var updatedBook = _bookConverter.Convert(updatedBookDto);

                updatedBook._id = book._id;

                await _bookService.UpdateAsync(id, updatedBook);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong" + $"{ex.Message}");
            }
        }

        // DELETE api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _bookService.RemoveAsync(id);

            return NoContent();
        }

    }
}