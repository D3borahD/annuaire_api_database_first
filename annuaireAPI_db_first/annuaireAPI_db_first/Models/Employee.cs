using System;
using System.Collections.Generic;
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
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Firstname { get; set; } = null!;
    [DataMember]
    public string Lastname { get; set; } = null!;
    [DataMember]
    public string Landline { get; set; } = null!;
    [DataMember]
    public string Mobile { get; set; } = null!;
    [DataMember]
    public string Email { get; set; } = null!;
    [DataMember]
    public int SiteId { get; set; }
    [DataMember]
    public int DepartmentId { get; set; }


    [JsonIgnore]
    [ForeignKey("DepartmentId")]
    public virtual Department Department { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("SiteId")]
    public virtual Site Site { get; set; } = null!;
}

