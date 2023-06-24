namespace Todo.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Todos
    {
        [Key]
        [Column("pkTodoId")]
        public int Id { get; set; }

        [Column("fkUserId")]
        public int UserId { get; set; }

        public string Description { get; set; }
    }
}
