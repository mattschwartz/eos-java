using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using eos.Models.Subjects;
using eos.Models.Users;
using eos.Views.Subjects.ViewModels;

namespace eos.Areas.Api.Controllers
{
    public class SubjectsController : BaseApiController
    {
        [HttpGet]
        public List<SubjectViewModel> GetSubjectsByUserId()
        {
            try {
                var userId = GetHeader("UserId");
                var subjects = UserManager.Context.Subjects.Where(t => t.UserId == userId);

                var result = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(subjects).ToList();
                return result;
            } catch (Exception) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}