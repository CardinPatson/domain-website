namespace Backend.Models
{
  public class Content
  {
    [Key]
    [Column("CONT_Id")]
    public int ContId { get; set; }

    [Column("CONT_Title")]
    public string ContTitle { get; set; } = string.Empty;

    [Column("CONT_Description")]
    public string ContDescription { get; set; } = string.Empty;
  }
}