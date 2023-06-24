namespace Todo.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Tasks
    {
        [Key]
        [Column("pkTaskId")]
        public int TaskId { get; set; }

        [Column("fkTodoId")]
        public int TodoId { get; set; }
        
        public string TaskName { get; set; }
        
        public string Status { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
