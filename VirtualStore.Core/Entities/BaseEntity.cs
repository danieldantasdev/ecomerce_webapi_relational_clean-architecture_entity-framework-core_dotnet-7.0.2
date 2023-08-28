using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public abstract class BaseEntity
{
    [Key] [Column("id")] public int Id { get; private set; }
    [Column("created_by")] public string CreatedBy { get; private set; }
    [Column("created_on")] public DateTime CreatedOn { get; private set; } = DateTime.Now;
    [Column("update_by")] public string UpdateBy { get; private set; }
    [Column("update_on")] public DateTime? UpdateOn { get; private set; }
    [Column("delete_by")] public string DeleteBy { get; private set; }
    [Column("delete_on")] public DateTime? DeleteOn { get; private set; }
}