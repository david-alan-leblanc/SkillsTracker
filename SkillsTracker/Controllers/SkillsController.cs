using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        // GET: /<controller>/
        [Route("/skills")]
        public IActionResult Index()
        {
            string html = "<h1>Skills Tracker</h1>" +
                "<h2>Coding skills to learn:</h2>" +
                "<ol><li>Alice</li><li>C#</li><li>Javascript</li></ol>";
            return Content(html, "text/html");
        }
    }

    public class SkillsFormController : Controller
    {
        string skillLevel = "<option value='Intro'>Intro</option><option value='Intermediate'>Intermediate</option><option value='Advanced'>Advanced</option>";
        // GET: /<controller>/
        [HttpGet]
        [Route("/skills/form")]
        public IActionResult CreateForm()
        {
            string html = "<form method = 'post' action='/skills/form/submitted'>" +
                "<label for='start'>Date:</label>" + "<br>" +
                "<input type='date' id='startDate' name='startDate' value='mm/dd/yyyy' min='2020-03-23' max='2020-06-22'>" + "<br>" +
                "<label for='language1'>Alice:<br></label><select id='Alice' name='Alice'>" + skillLevel + "</select>" + "<br>" +
                "<label for='language2'>C#:<br></label><select id='CSharp' name='CSharp'>" + skillLevel + "</select>" + "<br>" +
                "<label for='language3'>Javascript:<br></label><select id='Javascript' name='Javascript'>" + skillLevel + "</select>" + "<br>" +
                "<input type='submit' value='Submit'>" +
                "</form>";
            return Content(html, "text/html");
        }

        [HttpPost]
        [Route("/skills/form/submitted")]
        public IActionResult SubmitForm(string startDate, string Alice, string CSharp, string Javascript)
        {
            string html = $"<h1>{startDate}</h1>" +
                $"<ol><li>Alice: {Alice}</li><li>C#: {CSharp}</li><li>Javascript: {Javascript}</li></ol>";
            return Content(html, "text/html");
        }
    }
}
