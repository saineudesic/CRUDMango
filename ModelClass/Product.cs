using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelClass
{
    public class Product
    {

        public ObjectId Id { get; set; }

        //[BsonId]
        //[Key]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ProductId")]
        public string ProductId { get; set; }

        
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("UnitPrice")]
        public decimal UnitPrice { get; set; }

        //[Required(ErrorMessage = "Please Enter Description")]
        //[Column(TypeName = "varchar(500)")]
        //public string Description { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string ImageName { get; set; }

        //[Column(TypeName = "varchar(250)")]
        //public string ImagePath { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public DateTime? UpdatedDate { get; set; }
    }
}
