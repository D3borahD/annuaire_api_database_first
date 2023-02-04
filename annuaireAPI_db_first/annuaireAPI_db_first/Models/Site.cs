//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace annuaireAPI_db_first.Models;

public partial class Site
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
