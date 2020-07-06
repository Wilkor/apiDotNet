using System.ComponentModel.DataAnnotations;

namespace newprojet.models {

  public class Category {

    [Key]
   public int id {set; get;}

   [Required(ErrorMessage = "Este campo é obrigatório")]
   public string Title {get;set;}
  }


}