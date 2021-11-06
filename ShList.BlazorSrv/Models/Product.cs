using ShList.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Models
{
    public class Product
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Department { get;set; } = string.Empty;

        public Product()
        {
            Name = string.Empty;
            Department = string.Empty;
        }

        public Product(string name, string notes) : base()
        {
            Name = name;
            SetNotes(notes);
        }
        public void SetName(string name)
        {
            //add guard clause against null, empty is fine
            Name = name;
        }

        public void SetNotes(string notes)
        {
            //add guard clause against null, empty is fine
            Department = notes;
        }

        public Product(ProductDto dto) : this(dto.Name, dto.Department)
        {
            Department = dto.Department;
        }

    }
}

