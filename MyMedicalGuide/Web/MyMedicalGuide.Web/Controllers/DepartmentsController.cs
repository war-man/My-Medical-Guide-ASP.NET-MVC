﻿namespace MyMedicalGuide.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Web.Models.Departments;
    using System.IO;
    using System;
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentsService departmentsService;
        private readonly IHospitalsService hospitalsService;

        public DepartmentsController(IDepartmentsService departments, IHospitalsService hospitals)
        {
            this.departmentsService = departments;
            this.hospitalsService = hospitals;
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult All()
        {
            var departments = this.departmentsService.GetAll();
            var viewModelDepartments = this.Mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(viewModelDepartments);
        }

        [HttpGet]
        public ActionResult Details(int id, string hospitalId)
        {
            var department = this.departmentsService.GetDepartmentByIdFromParticularHospital(id, int.Parse(hospitalId));
            this.TempData["hospitalId"] = hospitalId;
            var viewModelDepartmentDetails = this.Mapper.Map<DepartmentViewModel>(department);
            return this.View(viewModelDepartmentDetails);
        }


    }
}