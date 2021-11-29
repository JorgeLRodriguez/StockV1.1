using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class RejectionType
    {
        #region "Constantes de Evento"
        //public const int ProductExpired = 1;
        //public const int DefectiveProduct = 2;
        //public const int FaultyPackaging = 3;
        //public const int SuitableProduct = 4;
        public const int ProductoVencido = 1;
        public const int ProductoDefectuoso = 2;
        public const int EmbalajeDefectuoso = 3;
        public const int ProductoApto = 4;

        #endregion 
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}