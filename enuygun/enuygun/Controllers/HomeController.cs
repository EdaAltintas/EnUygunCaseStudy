using Business.Abstract;
using DataAccess;
using enuygun.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace enuygun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessTaskService _businessTaskService ;
        private readonly IITTaskService _itTaskService;
        public readonly ApiData apis=new ApiData();

        public HomeController(ILogger<HomeController> logger, IBusinessTaskService businessTaskService,IITTaskService itTaskService)
        {
            _logger = logger;
            _businessTaskService = businessTaskService;
            _itTaskService = itTaskService;
        }

        public IActionResult Index()
        {
            SchedulePlan schedulePlan = new(_businessTaskService, _itTaskService);
            
            var plan= schedulePlan.GeneratePlan();
            return View(plan);
        }
    
        public JsonResult GetBusiness()=> Json(_businessTaskService.GetBusinessTasks());
     
        public JsonResult GetIts() => Json(_itTaskService.GetItTasks());
        [HttpPost]
        public JsonResult InsertDbProvider1()
        {
            var res2 = _itTaskService.AddBulk();
            string response = "";
            if (res2>0)
            {
                response = "Provider1 veritabanına yüklendi!";
            }
            else
            {
                response = "Yükleme işlemi başarısız!";
            }
            return Json(response);
        }
        [HttpPost]
        public JsonResult InsertDbProvider2()
        {
            var res1 = _businessTaskService.AddBulk();
            string response = "";
            if (res1 > 0)
            {
                response = "Provider2 veritabanına yüklendi!";
            }
            else
            {
                response = "Yükleme işlemi başarısız!";
            }
            return Json(response);
        }
    }
}
