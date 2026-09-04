// BEFORE

var cargos = db.Cargos.Where(cargo => cargo.IsActive).ToList();         

var rows = new List<object>();
foreach (var cargo in cargos)
    rows.Add(new {                  // In the loop
        cargo.RefNum,
        Origin = cargo.Origin.City, // Adds up 1 SQL query per each
        cargo.Note
    });  


// AFTER



var rows = db.Cargos.Where(c => c.IsActive)
    .OrderBy(c => c.Id)                 // Required for Skip / Take
    .Skip((page - 1) * size).Take(size) // Transated to OFFSET / FETCH 
    .Select(c => new CargoRow {         // JOIN, not lazy
        RefNum = c.RefNum, Origin = c.Origin.City, Note = c.Note })
    .ToList();



                                   