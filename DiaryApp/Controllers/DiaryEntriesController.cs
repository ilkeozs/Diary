using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers;

public class DiaryEntriesController : Controller
{
    private readonly ApplicationDbContext _context;
    public DiaryEntriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var objDiaryEntryList = _context.DiaryEntries.OrderByDescending(e => e.CreatedAt).ToList();
        return View(objDiaryEntryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DiaryEntry obj)
    {
        if (ModelState.IsValid)
        {
            _context.DiaryEntries.Add(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }

    [HttpGet]
    public IActionResult Read(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        DiaryEntry? diaryEntry = _context.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(diaryEntry);
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        DiaryEntry? diaryEntry = _context.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(diaryEntry);
    }

    [HttpPost]
    public IActionResult Update(DiaryEntry obj)
    {
        _context.DiaryEntries.Update(obj);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        DiaryEntry? diaryEntry = _context.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(diaryEntry);
    }

    [HttpPost]
    public IActionResult Delete(DiaryEntry obj)
    {
        _context.DiaryEntries.Remove(obj);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}