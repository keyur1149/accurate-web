using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accurate_data_access.DTO
{
    public class AddCategoryDTOs
    {
        [Required]
        [StringLength(25, ErrorMessage = "The Name field must be between 1 and 25 characters.")]
        public string Name {  get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
    public class EditCategoryDTOs
    {
        [Required]
        [StringLength(25, ErrorMessage = "The Name field must be between 1 and 25 characters.")]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
