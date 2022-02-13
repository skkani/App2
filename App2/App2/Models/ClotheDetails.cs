using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace App2.Models
{
    public class ClotheDetails
    {
        [PrimaryKey, AutoIncrement]
        public int ClotheId { get; set; }
        public string ClotheName { get; set; }
        public string ClotheGender { get; set; }
        public int Quantity { get; set; }
       
    }
}
