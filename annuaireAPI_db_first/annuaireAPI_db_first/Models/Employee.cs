using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace annuaireAPI_db_first.Models;

public partial class Employee
{
 
    public int Id { get; set; }
   
    public string Lastname { get; set; } = null!;
    public string Firstname { get; set; } = null!;

    public string Landline { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

  
    public int SiteId { get; set; }


    public int DepartmentId { get; set; }


    [JsonIgnore]
    public virtual Department? Department { get; set; }

    [JsonIgnore]
    public virtual Site? Site { get; set; }
}

