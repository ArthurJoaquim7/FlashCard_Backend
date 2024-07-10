using FlashCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlashCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardController : ControllerBase
    {
        private readonly Models.FlashCardDbContext _flashCardDbContext;

        public FlashCardController(FlashCardDbContext flashCardDbContext)
        {
            _flashCardDbContext = flashCardDbContext;
        }

        [HttpGet]
        [Route("GetFlashCard")]
        public async Task<IEnumerable<FlashCard>> GetFlashCards()
        {
            return await _flashCardDbContext.FlashCards.ToListAsync();
        }

        [HttpPost]
        [Route("AddFlashCard")]
        public async Task<FlashCard> AddFlashCard(FlashCard objflashCard)
        {
            _flashCardDbContext.FlashCards.Add(objflashCard);
            await _flashCardDbContext.SaveChangesAsync();
            return objflashCard;
        }

        [HttpPatch]
        [Route("UpdateFlashCard/{id}")]
        public async Task<FlashCard> UpdateFlashCard(FlashCard objflashCard)
        {
            _flashCardDbContext.Entry(objflashCard).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _flashCardDbContext.SaveChangesAsync();
            return objflashCard;
        }

        [HttpDelete]
        [Route("DeleteFlashCard/{id}")]
        public async Task<bool> DeleteFlashCard(int id)
        {
            bool a = false;
            var flashcard = await _flashCardDbContext.FlashCards.FindAsync(id);
            if (flashcard != null)
            {
                _flashCardDbContext.FlashCards.Remove(flashcard);
                await _flashCardDbContext.SaveChangesAsync();
                a = true;
            }
            return a;
        }
    }
}
