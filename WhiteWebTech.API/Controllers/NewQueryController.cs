using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteWebTech.API.Entities;
using WhiteWebTech.API.Models;
using WhiteWebTech.API.Services.IServices;

namespace WhiteWebTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewQueryController : ControllerBase
    {
        private readonly IGenericServices<NewQuery> genericServices;

        public IMapper _mapper;
        private ResponseDTO responseDTO;

        public NewQueryController(IGenericServices<NewQuery> genericServices, IMapper mapper)
        {
            this.genericServices = genericServices;
            _mapper = mapper;
            responseDTO = new ResponseDTO();
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await genericServices.GetAll();


                if (data != null)
                {
                    responseDTO.Result = _mapper.Map<List<NewQueryDTO>>(data);
                }
                else { responseDTO.Message = "No Record found !"; return Ok(responseDTO); }
            }
            catch (Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.IsSuccess = false;
            }
            return Ok(responseDTO);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var data = await genericServices.GetById(Id);
                if (data != null)
                {
                    responseDTO.Result = _mapper.Map<NewQueryDTO>(data);
                }
                else { responseDTO.Message = "No Record found !"; return Ok(responseDTO); }
            }
            catch (Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.IsSuccess = false;
            }
            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewQueryDTO newQueryDTO)
        {
            try
            {
                NewQuery newQuery = _mapper.Map<NewQuery>(newQueryDTO);
                var result = await genericServices.Create(newQuery);
                responseDTO.Result = result;
            }
            catch (Exception ex)
            {
                responseDTO.Message = ex.Message;
                responseDTO.IsSuccess = false;
                return Ok(responseDTO);
            }
            return Ok(responseDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(NewQueryDTO newQuery)
        {
            try
            {
                NewQuery query = _mapper.Map<NewQuery>(newQuery);
                await genericServices.Update(newQuery.Id, query);
                responseDTO.Result= query;
            }
            catch (Exception ex)
            {
                responseDTO.Message += ex.Message;
                responseDTO.IsSuccess = false;
            }
            return Ok(responseDTO);
        }









    }
}