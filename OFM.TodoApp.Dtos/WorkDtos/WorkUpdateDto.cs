using OFM.TodoApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Dtos.WorkDtos
{
    public class WorkUpdateDto : IDto
    {
        [Range(1,int.MaxValue,ErrorMessage = "Id Is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Defination Is Required.")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
