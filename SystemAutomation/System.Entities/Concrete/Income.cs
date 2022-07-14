using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class Income : IEntity
    {
        // TODO burda kaldım miktar girmeyince hata veriyor sistem onu düzelticen bütün classlara contructer ekleyip default değer ataması yapılcak
        public Income()
        {
            Quantity = 0.0;
            IncomeTypesId = 0;
            GiverPersonId = 0;
            ReceivingPersonId = 0;
            SpeciesId = 0;


        }
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int LastUpUser { get; set; }
        public DateTime LastUpDate { get; set; }
        public int IncomeTypesId { get; set; }
        public int GiverPersonId { get; set; }
        public int ReceivingPersonId { get; set; }
        public int SpeciesId { get; set; }
        public double Quantity { get; set; }
        public DateTime DateReceived { get; set; }
        public bool DeleteFlag { get; set; }
        public string Explanation { get; set; }
    }
}
