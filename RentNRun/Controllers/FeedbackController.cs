using Microsoft.AspNetCore.Mvc;
using RentNRunLib;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentNRun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        CarrentContext dc = new CarrentContext();
        // GET: api/<FeedbackController>
        [HttpGet]
        public IEnumerable<Feedback> Get()
        {
            var res = dc.Feedbacks;
            return res;
        }
        // GET api/<FeedbackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public Feedback Post(Feedback s)
        {
            dc.Feedbacks.Add(s);
            int i = dc.SaveChanges();
            if (i > 0)
            {
                return s;
            }
            else
            {
                return null;
            }
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
