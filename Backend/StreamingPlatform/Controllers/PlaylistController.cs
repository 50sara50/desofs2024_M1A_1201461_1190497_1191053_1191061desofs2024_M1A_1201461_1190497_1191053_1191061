using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using StreamingPlatform.Dtos;

namespace StreamingPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController(ILogger<AuthController> logger, IPlaylistService playlistService) : ControllerBase
    {

        /// <summary>
        /// Add new playlist
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreatePlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePlaylist([FromBody] NewPlaylistContract newPlaylistContract)
        {
            try
            {
                PlaylistResponseDto playlist = await playlistService.AddPlaylist(newPlaylistContract);
                logger.LogInformation(
                    $"New playlist '${newPlaylistContract.Title}' added on user's '${playlist.UserId}' account.");
                return this.Ok(playlist);
            }
            catch (ValidationException v)
            {
                logger.LogError($"Validation exception: ${v.Message}.");
                return this.BadRequest(v.Message);
            }
            catch (InvalidOperationException i)
            {
                logger.LogError($"Invalid operation exceptions: ${i.Message}.");
                return this.Conflict(i.Message);
            }
            catch (Exception e)
            {
                logger.LogError($"Exception: ${e.Message}.");
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Add a song to the playlist.
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        [HttpPatch("AddSongToPlaylist")]
        public async Task<PlaylistResponseDto> AddSong([FromBody] AddSongToPlaylistContract contract)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets user's playlists.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("GetUserPlaylists")]
        public async Task<IEnumerable<PlaylistResponseDto>> GetUserPlaylists([FromQuery] string userId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}