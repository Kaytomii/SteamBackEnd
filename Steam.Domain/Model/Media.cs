using Steam.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Steam.Domain.Model;

public class Media : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("url")]
    public string Url { get; set; } = null!;

    [Column("type")]
    public MediaType Type { get; set; }

    [Column("file_name")]
    public string FileName { get; set; } = null!;

    [Column("size")]
    public long Size { get; set; }
}
