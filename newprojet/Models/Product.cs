using System.ComponentModel.DataAnnotations;

namespace newprojet.models {

  public class Product {

    [Key]
   public int id {set; get;}

   [Required(ErrorMessage = "Este campo é obrigatório")]
   public string Title {get;set;}

   public string Description {get; set;}

   public decimal Price {get; set;}

   public int CategoryId {get;set;}

   public Category Category {get; set;}

  }


}