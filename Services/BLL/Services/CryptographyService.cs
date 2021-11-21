using Services.BLL.Contracts;
using Services.Services.Security;
using System;

namespace Services.BLL.Services
{
    /// <summary>
    /// Ofrece un punto de acceso a los servicios de criptografía desde la BLL
    /// </summary>
    class CryptographyService : ICryptographyService
    {
        private readonly CSP _csp;
        private static CryptographyService _default;
        public static CryptographyService Default
        {
            get
            {
                if (_default == null)
                    throw new InvalidOperationException("Debe configurar un servicio por defecto antes de utilizar esta funcionalidad");

                return _default;
            }
            set { _default = value; }
        }
        public CryptographyService(string base64SaltKey)
        {
            _csp = new CSP(base64SaltKey);
        }
        public string Encrypt(string textoPlano)
        {
            var bytes = _csp.EncryptString(textoPlano);
            return Convert.ToBase64String(bytes);
        }
        public string Decrypt(string textoCifrado)
        {
            var bytes = Convert.FromBase64String(textoCifrado);
            return _csp.DecryptString(bytes);
        }
    }
}
