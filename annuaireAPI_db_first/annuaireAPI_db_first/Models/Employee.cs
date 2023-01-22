using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace annuaireAPI_db_first.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Landline { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int SiteId { get; set; }

    public int DepartmentId { get; set; }

    [JsonIgnore]
    public virtual Department Department { get; set; } = null!;

    [JsonIgnore]
    public virtual Site Site { get; set; } = null!;
}
