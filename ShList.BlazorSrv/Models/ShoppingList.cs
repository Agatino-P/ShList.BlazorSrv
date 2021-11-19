using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShList.BlazorSrv.Models
{
    public class ShoppingList
    {
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        private readonly List<ShItem> _items = new();

        public ShoppingList()
        {
            Id = Guid.NewGuid();

        }
        public ShoppingList(ShoppingListDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Created = dto.Created;
            if (dto.Items != null)
            {

                foreach (ShItemDto dtoItem in dto.Items)
                {
                    AddItem(new ShItem(dtoItem));
                }
            }

        }

        public ShoppingListDto ToDto()
        {
            return new ShoppingListDto(Id, Name, Created, _items.Select(item => item.ToDto()));
        }

        public ReadOnlyCollection<ShItem> Items => _items.AsReadOnly();

        public void AddItem(Product product)
        {
            if (!_items.Exists(i => i.Product == product.Name))
            {
                _items.Add(new ShItem(product));
            }
        }

        public void AddItem(ShItem item)
        {
            if (!_items.Exists(i => i == item))
            {
                _items.Add(item);
            }
        }

        public void RemoveItem(ShItem item)
        {
            if (_items.Exists(i => i == item))
            {
                _items.Remove(item);
            }
        }

        internal void SetItemStatus(ShItem item, ShItemStatus status)
        {
            if (_items.Exists(i => i == item))
            {
                item.Status=status;
            }
        }

        //public void UpdateItem(ShItem shItem)
        //{
        //    int position = _items.IndexOf(shItem);
        //    if (position <0 )
        //    {
        //        return;
        //    }

        //    _items

        //}

    }
}
