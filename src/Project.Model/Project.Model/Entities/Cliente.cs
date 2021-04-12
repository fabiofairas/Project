using System;

namespace Project.Model.Entities
{
    public class Cliente : BaseEntity
    {   
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}