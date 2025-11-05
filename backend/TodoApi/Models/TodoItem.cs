using System.ComponentModel.DataAnnotations;

public class ToDoItem
{
	public int Id { get; set; }
	[Required]
	public string? Tytul {  get; set; }
	public string? Opis { get; set; }
	public bool CzyZrobione { get; set; } = false;
}
