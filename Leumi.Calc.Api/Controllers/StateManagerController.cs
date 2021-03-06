/*
 * Leumi calculator task
 *
 * This is an example of using OAuth2 Password Flow in a specification to describe security to your API.
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Leumi.Calc.Application.Services;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("/leumi/calc/memory")]
    public class StateManagerController : ControllerBase
    { 

        private readonly ICalculatorService calculatorService;
        public StateManagerController(ICalculatorService calculatorService)
        {

            this.calculatorService = calculatorService;
        }
        /// <summary>
        /// Clear the memory value
        /// </summary>
        /// <remarks>Remove the value stored on memory</remarks>
        /// <response code="200">OK</response>
        [HttpDelete] 
        [SwaggerOperation("/clearMemory")]
        public virtual IActionResult ClearMemory()
        {
            calculatorService.DeleteMemoryValue();

            return Ok();
        }

        /// <summary>
        /// Save the last result on memory
        /// </summary>
        /// <remarks>Store last operation result in memory</remarks>
        /// <response code="200">OK</response>
        [HttpPost]
        [SwaggerOperation("/saveToMemory")]
        public virtual IActionResult SaveToMemory([FromBody] double value)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            calculatorService.AddMemoryValue(value);

            return Ok();
        }

        /// <summary>
        /// Return the value stored on memory
        /// </summary>
        /// <response code="200">value in memory</response>
        [HttpGet]
        [SwaggerOperation("/showMemory")]
        [SwaggerResponse(statusCode: 200, type: typeof(double?), description: "value in memory")]
        public virtual IActionResult ShowMemory()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(double?));

            
            return Ok(calculatorService.GetMemoryValue());

            //string exampleJson = null;
            //exampleJson = "0.8008281904610115";
            
            //            var example = exampleJson != null
            //            ? JsonConvert.DeserializeObject<double?>(exampleJson)
            //            : default(double?);            //TODO: Change the data returned
            //return new ObjectResult(example);
        }
    }
}
