using ShList.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Models
{
    public class ShItem
    {
        public Guid Id { get;  set; }
        [Required]
        public string Product { get;  set; }

        public string Department { get;  set; }
        public string Shop{ get;  set; }
        [Range(0,1000)]
        public int Quantity { get;  set; }
        public ShItemStatus Status { get;  set; }
        public ShItem(ShItemDto dto)
        {
            Product = dto.Product;
            Department = dto.Department;
            Shop = dto.Shop;
            Quantity = dto.Quantity;
            Status = Enum.Parse<ShItemStatus>(dto.Status);
        }

        public ShItem(Product product)
        {
            Product = product.Name;
            Department = product.Department;
        }

        public ShItemDto ToDto()
        {
            return new ShItemDto(Id, Product, Department, Shop, Quantity, Status.ToString());
        }
    }
}
