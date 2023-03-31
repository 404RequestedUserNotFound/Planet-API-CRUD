using Planet_API_CRUD.EF;
using Planet_API_CRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Planet_API_CRUD.Controllers
{
    public class PlanetController : ApiController
    {
        [HttpGet]
        [Route("api/planets")]
        public HttpResponseMessage AllPlanets()
        {
            PlanetContext db = new PlanetContext();
            var data = db.Planets.ToList();
            if (data.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        [HttpGet]
        [Route("api/planets/{id}")]
        public HttpResponseMessage GetPlanets(int id)
        {
            PlanetContext db = new PlanetContext();
            var data = db.Planets.Find(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Planet not found");
        }



        [HttpPost]
        [Route("api/planets/add")]
        public HttpResponseMessage AddPlanet (Planet planet)
        {
            PlanetContext db = new PlanetContext();
            try
            {
                db.Planets.Add(planet);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Planet information inserted");

            }

            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }





        [HttpPost]
        [Route("api/planets/update")]
        public HttpResponseMessage EditPlanet (Planet planet)
        {
            PlanetContext db = new PlanetContext();
            var exeplanet = db.Planets.Find(planet.Id);
            if (exeplanet != null) 
            {
                try
                {
                    db.Entry(exeplanet).CurrentValues.SetValues(planet);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Planet Information Updated");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse (HttpStatusCode.BadRequest, ex.Message);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Planet Not Found");

        }




        [HttpDelete]
        [Route("api/planets/{id}")]
        public HttpResponseMessage DeletePlanets(int id)
        {
            PlanetContext db = new PlanetContext();
            var data = db.Planets.Find(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            db.Planets.Remove(data);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.NotFound, "Planet deleted from the universe");
        }





    }
}
