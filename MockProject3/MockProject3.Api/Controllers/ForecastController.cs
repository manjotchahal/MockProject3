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
    [Route("api/[controller]")]
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
        // GET: api/forecast/Users
        [Route("Users")]
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
                        return NotFound("There are no users in the database.");
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
        /// <remarks>
        /// The format for startDate is yyyy-mm-dd
        /// </remarks>
        /// <return>
        /// Return a list of all Users in the database with the match search critiea.
        /// </return>
        // GET: api/forecast/Users/startDate
        [HttpGet("Users/{startDate:datetime}")]
        public IActionResult Get(DateTime startDate)
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
        /// <remarks>
        /// The format for startDate and endDate is yyyy-mm-dd
        /// </remarks>
        /// <return>
        /// Return a list of all Users in the database with the match search critiea.
        /// </return>
        // GET: api/forecast/Users/startDate/endDate
        [HttpGet("Users/{startDate:datetime}/{endDate:datetime}")]
        public IActionResult Get(DateTime startDate, DateTime endDate)
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

        /// <summary>
        /// This endpoint will return all Users to the caller using the search critiea of startdate, enddate, and office location.
        /// </summary>
        /// <remarks>
        /// The format for startDate and endDate is yyyy-mm-dd and the format of location is city name
        /// </remarks>
        /// <return>
        /// Return a list of all Users in the database with the match search critiea.
        /// </return>
        // GET: api/forecast/Users/startDate/endDate/location
        [HttpGet("Users/{startDate:datetime}/{endDate:datetime}/{location:string}")]
        public IActionResult Get(DateTime startDate, DateTime endDate, string location)
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
                    users = db.Users.Where(u => u.DateCreated <= startDate && u.DateDeleted <= endDate && u.Location == location).ToList();
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