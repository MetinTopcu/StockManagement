using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Customer.Domain.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        //Kullanıcı siparişlerini sipariş id olarak burada 1<->n ilişkisi olarak tutacağım. Bu kısım değişebilir.
        public ICollection<int>? OrderId { get; set; }
    }
}
