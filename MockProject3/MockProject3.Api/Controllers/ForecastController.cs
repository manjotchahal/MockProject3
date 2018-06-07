using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MockProject3.DA.Models;
using MockProject3.DA;
using NLog;

namespace MockProject3.Api.Controllers
{ 
    [Produces("application/json")]
    [Route("api/Forecast")]
    public class ForecastController : Controller
    {
        // Logger object to log errors to a file.
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// This endpoint will return all Users to the caller.
        /// </summary>
        /// <return>
        /// Return a list of all Users in the database.
        /// </return>
        [Route("~api/Forecast/Users")]
        [HttpGet]
        public IActionResult Get() // .NET Core doesn't have IHttpActionResult instead we use IActionResult
        {
            try
            {
                List<User> users = new List<User>();
                using (ForecastContext db = new ForecastContext())
                {
                    // Lets query the db for the users
                    users = db.Users.ToList();
                    if (users == null)
                    {
                        return BadRequest("There are no users in the database.");
                    }
                }
                    return Ok(users);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Error occurred while processing request."); // Return an empty list
            }
        }

        /// <summary>
        /// This endpoint will return all Users to the caller using the search critiea of startdate.
        /// </summary>
        /// <return>
        /// Return a list of all Users in the database.
        /// </return>
        [Route("~api/Forecast/Users")]
        [HttpGet]
        public IActionResult Get([FromBody]DateTime startDate)
        {
            try
            {
                // check if the models are correct?
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not valid input");
                }

                List<User> users = new List<User>();

                using (ForecastContext db = new ForecastContext())
                {
                    users = db.Users.Where(u => u.DateCreated <= startDate).ToList();
                    if (users == null)
                    {
                        return NotFound("No users found with the passed search critiea.");
                    }

                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }

        /// <summary>
        /// This endpoint will return all Users to the caller using the search critiea of startdate and enddate.
        /// </summary>
        /// <return>
        /// Return a list of all Users in the database.
        /// </return>
        [Route("~api/Forecast/Users")]
        [HttpGet]
        public IActionResult Get([FromBody]DateTime startDate, [FromBody]DateTime endDate)
        {
            try
            {
                // check if the models are correct?
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not valid input");
                }

                List<User> users = new List<User>();

                using (ForecastContext db = new ForecastContext())
                {
                    users = db.Users.Where(u => u.DateCreated <= startDate && u.DateDeleted <= endDate).ToList();
                    if (users == null)
                    {
                        return NotFound("No users found with the passed search critiea."); 
                    }

                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }
    }
}