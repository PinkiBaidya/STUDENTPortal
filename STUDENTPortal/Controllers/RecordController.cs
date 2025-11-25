using Microsoft.AspNetCore.Mvc;
using STUDENTPortal.Data;
using STUDENTPortal.Models;

namespace STUDENTPortal.Controllers
{
    public class RecordController : Controller
    {
        private readonly AppDbContext _context;

        public RecordController(AppDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            IEnumerable<Record> records = _context.Records.ToList();
            return View(records);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create([Bind("StudentId, FullName, Email, DateOfBirth, RegistrationDate, Department")]Record model)
		{
			if(ModelState.IsValid)
            {
                _context.Records.Add(model);
                _context.SaveChanges();
                TempData["Notification"] = "Created Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
            }
            return View(model);
		}
        public IActionResult Edit(int id)
        {
            var record = _context.Records.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            else
            {
                return View(record);
            }
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id, StudentId, FullName, Email, DateOfBirth, RegistrationDate, Department")]Record record)
        {
			if(ModelState.IsValid)
			{
				_context.Records.Update(record);
				_context.SaveChanges();
                TempData["Notification"] = "Updated Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
			}
			return View(record);
		}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _context.Records.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            else
            {
                return View(record);
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            var record = _context.Records.Find(id);
            if(record != null)
            {
                _context.Records.Remove(record);
                _context.SaveChanges();
                TempData["Notification"] = "Deleted Successfully";
                TempData["NotificationType"] = "success";
            }
            return RedirectToAction("Index");
        }
	}
}
