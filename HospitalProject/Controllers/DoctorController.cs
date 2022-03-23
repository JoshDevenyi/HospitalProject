using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using HospitalProject.Models;


namespace HospitalProject.Controllers
{
    public class DoctorController : Controller
    {

        private static readonly HttpClient client;

        static DoctorController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44323/api/doctordata/");
        }

        // GET: Doctor/List
        public ActionResult List()
        {
            //objective: communicate with doctor data api to retrieve a list of doctors
            //curl https://localhost:44323/api/doctordata/listdoctors

            string url = "listdoctors";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<DoctorDto> doctors = response.Content.ReadAsAsync<IEnumerable<DoctorDto>>().Result;

            //Debug.WriteLine("Number of Doctors: ");
            //Debug.WriteLine(doctors.Count());

            return View(doctors);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {

            //objective: communicate with doctor data api to retrieve one doctor
            //curl https://localhost:44323/api/doctordata/finddoctors/{id}

            string url = "finddoctor/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            DoctorDto SelectedDoctor = response.Content.ReadAsAsync<DoctorDto>().Result;

            //Debug.WriteLine("Doctor Recieved: ");
            //Debug.WriteLine(SelectedDoctor.DoctorFirstName +" "+SelectedDoctor.DoctorLastName);

            return View(SelectedDoctor);
        }

        // GET: Doctor/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            Debug.WriteLine("The inputted doctor name is ");
            Debug.WriteLine(doctor.DoctorFirstName);
            Debug.WriteLine(doctor.DoctorLastName);

            return RedirectToAction("List");
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
