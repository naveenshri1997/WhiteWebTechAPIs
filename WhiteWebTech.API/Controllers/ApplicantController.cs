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
    public class ApplicantController : ControllerBase
    {
        private readonly IGenericServices<Applicant> genericServices;

        public IMapper _mapper;
        private ResponseDTO responseDTO;

        public ApplicantController(IGenericServices<Applicant> genericServices, IMapper mapper)
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
                    responseDTO.Result = _mapper.Map<List<ApplicantDTO>>(data);
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
                    responseDTO.Result = _mapper.Map<ApplicantDTO>(data);
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
        public async Task<IActionResult> Create([FromBody] ApplicantDTO applicantDTO)
        {
            try
            {
                Applicant applicant = _mapper.Map<Applicant>(applicantDTO);
                var result = await genericServices.Create(applicant);
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
        public async Task<IActionResult> Update(ApplicantDTO applicantDTO)
        {
            try
            {
                Applicant applicant = _mapper.Map<Applicant>(applicantDTO);
                await genericServices.Update((int)applicant.Id, applicant);
                responseDTO.Result = applicantDTO;
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
