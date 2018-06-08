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
using MockProject3.DA.Repos;

namespace MockProject3.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        // Logger object to log errors to a file.
        private Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IRepo<User> _userRepo;
        private readonly IRepo<Room> _roomRepo;
        public ForecastController(IRepo<User> userRepo, IRepo<Room> roomRepo)
        {
            _userRepo = userRepo;
            _roomRepo = roomRepo;
        }


        /// <summary>
        /// This endpoint will return all unique locations of rooms
        /// </summary>
        /// <return>
        /// Return a list of all unique locations of rooms.
        /// </return>
        // GET: api/forecast/Locations
        [HttpGet("Locations")]
        public IActionResult GetLocations()
        {
            try
            {

                List<string> locations = _roomRepo.GetLocations().ToList();
                if (locations.Count == 0)
                {
                    return NotFound("No locations found.");
                }
                return Ok(locations);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }

        /// <summary>
        /// This endpoint will return the total count of Users and Rooms to the caller.
        /// </summary>
        /// <return>
        /// Return the total count of Users and Rooms in the database.
        /// </return>
        // GET: api/forecast/Users
        [Route("Users")]
        [HttpGet]
        public IActionResult Get() // .NET Core doesn't have IHttpActionResult instead we use IActionResult
        {
            try
            {
                List<User> users = new List<User>();
                List<Room> rooms = new List<Room>();


                // Lets query the db for the users and rooms
                users = _userRepo.Get().ToList();
                rooms = _roomRepo.Get().ToList();
                if (users == null || rooms == null)
                {
                    return NotFound("There are no users/rooms in the database.");
                }


                // Return the snapshot
                var snapshot = new Snapshot()
                {
                    Date = DateTime.MinValue,
                    UserCount = users.Count,
                    RoomCount = rooms.Count,
                    Location = "ALL"
                };
                return Ok(snapshot);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Error occurred while processing request."); // Return an empty list
            }
        }

        /// <summary>
        /// This endpoint will return the total count of Users and Rooms to the caller using the search criteria of date.
        /// </summary>
        /// <remarks>
        /// The format for date is yyyy-mm-dd
        /// </remarks>
        /// <param name="date">The date the search should start from.</param>
        /// <return>
        /// Return the total number of Users and Rooms in the database with the match search criteria.
        /// </return>
        // GET: api/forecast/Snapshots/date
        [HttpGet("Snapshots/{date:datetime}")]
        public IActionResult Get(DateTime date)
        {
            try
            {
                // check if the models are correct?
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not valid input");
                }

                List<User> users = new List<User>();
                List<Room> rooms = new List<Room>();


                // Get all users that were created on/before the startDate and has been deleted
                users = _userRepo.GetByDate(date).ToList();
                rooms = _roomRepo.GetByDate(date).ToList();
                if (users == null || rooms == null)
                {
                    return NotFound("No users/rooms found with the passed search critiea.");
                }

                // Return the snapshot
                var snapshot = new Snapshot()
                {
                    Date = date,
                    UserCount = users.Count,
                    RoomCount = rooms.Count,
                    Location = "All"
                };
                return Ok(snapshot);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }

        /// <summary>
        /// This endpoint will return the total count of Users and Rooms to the caller using the search critiea of startdate and enddate.
        /// </summary>
        /// <remarks>
        /// The format for startDate and endDate is yyyy-mm-dd
        /// </remarks>
        /// <param name="startDate">The starting date for the search.</param>
        /// <param name="endDate">The ending date for the search.</param>
        /// <return>
        /// Return the total number of Users and Rooms in the database with the match search critiea.
        /// </return>
        // GET: api/forecast/SnapshotsRange/startDate/endDate
        [HttpGet("SnapshotsRange/{startDate:datetime}/{endDate:datetime}")]
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
                List<Room> rooms = new List<Room>();


                // Find all users that were created within the range of startDate and endDate that aren't deleted
                users = _userRepo.GetBetweenDates(startDate, endDate).ToList();
                rooms = _roomRepo.GetBetweenDates(startDate, endDate).ToList();
                if (users == null || rooms == null)
                {
                    return NotFound("No users/rooms found with the passed search critiea.");
                }

                // Return the snapshot
                var snapshot = new Snapshot()
                {
                    Date = startDate,
                    UserCount = users.Count,
                    RoomCount = rooms.Count,
                    Location = "ALL"
                };
                return Ok(snapshot);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }

        /// <summary>
        /// This endpoint will return the total count of Users and Rooms to the caller using the search critiea of startdate, enddate, and office location.
        /// </summary>
        /// <remarks>
        /// The format for startDate and endDate is yyyy-mm-dd and the format of location is city name
        /// </remarks>
        /// <param name="startDate">The starting date for the search.</param>
        /// <param name="endDate">The ending date for the search.</param>
        /// <param name="location">The location the search should be focused on.</param>
        /// <return>
        /// Return the total number of Users and Rooms in the database with the match search critiea.
        /// </return>
        // GET: api/forecast/SnapshotsRangeByLocation/startDate/endDate/location
        [HttpGet("SnapshotsRangeByLocation/{startDate:datetime}/{endDate:datetime}/{location:alpha}")]
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
                List<Room> rooms = new List<Room>();


                // Find all users that were created within the range of startDate and endDate that aren't deleted
                users = _userRepo.GetBetweenDatesAtLocation(startDate, endDate, location).ToList();
                rooms = _roomRepo.GetBetweenDatesAtLocation(startDate, endDate, location).ToList();
                if (users == null || rooms == null)
                {
                    return NotFound("No users/rooms found with the passed search critiea.");
                }

                // Return the snapshot
                var snapshot = new Snapshot()
                {
                    Date = startDate,
                    UserCount = users.Count,
                    RoomCount = rooms.Count,
                    Location = location
                };
                return Ok(snapshot);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest("Something went wrong while processing the request.");
            }
        }
    }
}