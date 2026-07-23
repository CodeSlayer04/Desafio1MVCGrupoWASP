
using Desafio1MVCGrupoWASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class EmpleadosController : Controller
{
    private readonly AppDBContext _context;

    public EmpleadosController(AppDBContext context)
    {
        _context = context;
    }

    // GET: EMPLEADOS
    public async Task<IActionResult> Index(int? departamentoId)    
    {
        
        var query = _context.Empleado.Include(e => e.Departamento).AsQueryable();

        if (departamentoId.HasValue)
        {
            query = query.Where(e => e.DepartamentoId == departamentoId.Value);

            var dpto = await _context.Departamentos.FindAsync(departamentoId.Value);
            ViewData["DepartamentoFiltro"] = dpto?.Nombre;
        }

        return View(await query.ToListAsync());
    }

    // GET: EMPLEADOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado
            .Include(e => e.Departamento)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // GET: EMPLEADOS/Create
    public IActionResult Create()
    {
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Nombre");
        return View();
    }

    // POST: EMPLEADOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Nombre,FechaNacimiento,FechaContratacion,Salario,Descripcion,DepartamentoId,Departamento")] Empleado empleado)
    {
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Nombre");
        if (ModelState.IsValid)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado.FindAsync(id);
        if (empleado == null)
        {
            return NotFound();
        }
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Nombre", empleado.DepartamentoId);

        return View(empleado);
    }

    // POST: EMPLEADOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ID,Nombre,FechaNacimiento,FechaContratacion,Salario,Descripcion,DepartamentoId,Departamento")] Empleado empleado)
    {
        if (id != empleado.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(empleado.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleado
            .FirstOrDefaultAsync(m => m.ID == id);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // POST: EMPLEADOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var empleado = await _context.Empleado.FindAsync(id);
        if (empleado != null)
        {
            _context.Empleado.Remove(empleado);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpleadoExists(int? id)
    {
        return _context.Empleado.Any(e => e.ID == id);
    }
}
