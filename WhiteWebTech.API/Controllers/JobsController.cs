using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteWebTech.API.Entities;
using WhiteWebTech.API.Models;
using WhiteWebTech.API.Services.IServices;

namespace WhiteWebTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IGenericServices<Job> genericServices;

        public IMapper _mapper;
        private ResponseDTO responseDTO;

        public JobsController(IGenericServices<Job> genericServices, IMapper mapper)
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
                    responseDTO.Result = _mapper.Map<List<JobsDTO>>(data);
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
                    responseDTO.Result = _mapper.Map<JobsDTO>(data);
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
        public async Task<IActionResult> Create([FromBody] JobsDTO jobsDTO)
        {
            try
            {
                Job job = _mapper.Map<Job>(jobsDTO);
                var result = await genericServices.Create(job);
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
        public async Task<IActionResult> Update(JobsDTO jobsDTO)
        {
            try
            {
                Job job = _mapper.Map<Job>(jobsDTO);
                await genericServices.Update(job.Id, job);
                responseDTO.Result = jobsDTO;
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
