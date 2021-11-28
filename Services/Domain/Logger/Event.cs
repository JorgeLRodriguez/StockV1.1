using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Logger
{
    public class Event
    {
        #region "Constantes de Evento"
        public const int UsuarioIngresoAlSistema = 1;
        public const int UsuarioSalioDelSistema = 2;
        public const int UsuarioFalloIngresandoCredenciales = 3;
        public const int ComprobanteGenerado = 4;
        public const int AltaDestinatario = 5;
        public const int ComprobanteActualizado = 6;
        public const int ErrorDeSistema = 7;

        #endregion 
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}