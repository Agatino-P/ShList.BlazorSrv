using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Notes { get; private set; } = string.Empty;

        //for EF
        private Product()
        {
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

