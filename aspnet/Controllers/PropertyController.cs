using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Repositories;
using aspnet.Models;
using aspnet.dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace aspnet.Controllers
{
    [ApiController]
    [Route("api/prop")]
    
    public class PropertyController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _map;

        public PropertyController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        
        [HttpGet]
        public ActionResult GetAllProp(){
            return Ok(_map.Map<IEnumerable<PropertyReadDto>>(_repo.GetAllProp()));
        }

        [HttpGet("{id}", Name="GetPropById")]
        public ActionResult GetPropById(int id){
            return Ok(_map.Map<PropertyReadDto>(_repo.GetPropById(id)));
        }

        [HttpPost]
        public ActionResult AddProp(PropertyWriteDto t){
            var prop = _map.Map<Property>(t);

            _repo.AddProp(prop);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetPropById), new {Id = prop.Id}, prop);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProp(int id, PropertyUpdateDto t)
        {
            var existingProp = _repo.GetPropById(id);

            if(existingProp == null){
                return NotFound();
            }

            _map.Map(t, existingProp);

            _repo.UpdateProp(existingProp);

            _repo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProp(int id)
        {
            var existingProp = _repo.GetPropById(id);

            if(existingProp == null){
                return NotFound();
            }

            _repo.DeleteProp(existingProp);
            _repo.SaveChanges();
            return Ok();
        }
    }


}