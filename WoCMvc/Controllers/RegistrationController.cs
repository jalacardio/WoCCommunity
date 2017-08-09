using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoCMvc.Controllers
{
    public class RegistrationController : Controller
    {
        private IHostingEnvironment _environment;

        public RegistrationController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // POST: /Registration/UploadResume/
        [HttpPost]
        public async Task<IActionResult> UploadResume(List<IFormFile> files)
        {
            //Do something with the files here. 
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    ViewData["filename"] = file.FileName;
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            ParseResume();
            return View();
        }

        private void ParseResume()
        {
            var processInfo = new ProcessStartInfo("C:\\Program Files\\Java\\jdk1.8.0_101\\bin\\java.exe", "$env:GATE_HOME=\"..\\GATEFiles\"  java -cp '.\\bin\\*;..\\GATEFiles\\lib\\*;..\\GATEFILES\\bin\\gate.jar;.\\lib\\*' code4goal.antony.resumeparser.ResumeParserProgram .\\UnitTests\\AntonyDeepakThomas.pdf D:\\antony_thomas.json")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };

            processInfo.WorkingDirectory = "D:\\Work\\Research\\ResumeParser\\ResumeTransducer"; // this is where your jar file is.
            Process proc;

            if ((proc = Process.Start(processInfo)) == null)
            {
                throw new InvalidOperationException("??");
            }

            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            Debug.WriteLine(exitCode);
        }
    }
}
