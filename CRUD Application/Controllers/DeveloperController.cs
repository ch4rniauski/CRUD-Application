﻿using CRUD_Application.Records;
using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.DataContext.Repository;
using GamesMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperRecord>?>> GetAllDevelopers()
        {
            List<DeveloperEntity> developersList = await _developerRepository.GetAllDevepers();
            List<DeveloperRecord>? recordsList = null;

            if (developersList is not null)
            {
                recordsList = new();

                foreach (DeveloperEntity developer in developersList)
                {
                    DeveloperRecord record = new(developer.Id, developer.Name);
                    recordsList.Add(record);
                }
            }
            return Ok(recordsList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeveloperEntity>> GetDeveloper(Guid id)
        {
            var developer = await _developerRepository.GetDeveper(id);

            if (developer is null)
                return NotFound("Developer with that ID wasn't found");
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult<DeveloperEntity>> CreateDeveloper([FromBody] Developer developer)
        {
            return Ok(await _developerRepository.CreateDeveper(developer.Id, developer.Name));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteDeveloper(Guid id)
        {
            bool isDeleted = await _developerRepository.DeleteDeveper(id);

            if (!isDeleted)
                return NotFound("Developer with that ID wasn't found");
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DeveloperEntity>> UpdateDeveloper(Developer developer)
        {
            var updatedDeveloper = await _developerRepository.UpdateDeveper(developer.Id, developer.Name);

            if (updatedDeveloper is null)
                return BadRequest("Developer wasn't updated");
            return Ok(updatedDeveloper);
        }
    }
}
