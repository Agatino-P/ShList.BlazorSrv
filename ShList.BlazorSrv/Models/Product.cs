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
        public Guid Id { get; private set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Notes { get;set; } = string.Empty;

        public Product()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Notes = string.Empty;
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
            Notes = notes;
        }

        public Product(ProductDto dto) : this(dto.Name, dto.Notes)
        {
            Id = dto.Id;
        }

    }
}

