using System;
using System.Linq;

namespace VendaWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set;} = new List<Seller>();

        // Criar um construtor vazio
        public Department() { }

        // Não incluir as coleções nos construtores
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Metodo
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial,final));
        }
    }
}
