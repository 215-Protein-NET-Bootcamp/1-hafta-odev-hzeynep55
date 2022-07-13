using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ProteinBootcampHomework1.AddControllers {

    public class CommonResponse<T>
    {
        public CommonResponse(T data)
        {
            Data = data;
        }
        public CommonResponse(string error)
        {
            Error = error;
            Success = false;
        }
        public bool Success { get; set; } = true;
        public string Error { get; set; }
        public T Data { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        public CalculatorController()
        {

        }




        private static CommonResponse<List<Calculator>> Amount()
        {
            List<Calculator> list = new();

            list.Add(new Calculator { id = 1, defferend = 12, amount = 20000 });
            list.Add(new Calculator { id = 2, defferend = 36, amount = 36000 });

            return new CommonResponse<List<Calculator>>(list);
        }
        [HttpGet]
        public CommonResponse<List<Calculator>> Get()
        {
            return Amount();
        }
        [HttpPost]
        public CommonResponse<List<Calculator>> Post([FromBody] Calculator calculator)
        {
            List<Calculator> list = Amount().Data;
            list.Add(calculator);
            return new CommonResponse<List<Calculator>>(list.ToList());
        }

        [HttpPut]
        public CommonResponse<List<Calculator>> Put([FromBody] Calculator request)
        {
            List<Calculator> list = Amount().Data;
            Calculator calculator = list.Where(x => x.id == request.id).FirstOrDefault();
            list.Remove(calculator);
            list.Add(request);
            return new CommonResponse<List<Calculator>>(list.ToList());
        }

        [HttpDelete("{id}")]
        public CommonResponse<List<Calculator>> Delete([FromRoute] long id)
        {
            List<Calculator> list =Amount().Data;
            Calculator calculator = list.Where(x => x.id == id).FirstOrDefault();
            list.Remove(calculator);
            return new CommonResponse<List<Calculator>>(list.ToList());
        }








    }



}

