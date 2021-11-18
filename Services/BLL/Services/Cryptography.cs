﻿using Services.BLL.Contracts;
using Services.Services.Security;
using System;

namespace Services.BLL.Services
{
    /// <summary>
    /// Ofrece un punto de acceso a los servicios de criptografía desde la BLL
    /// </summary>
    class Cryptography : ICryptography
    {
        private readonly CSP _csp;
        private static Cryptography _default;
        public static Cryptography Default
        {
            get
            {
                if (_default == null)
                    throw new InvalidOperationException("Debe configurar un servicio por defecto antes de utilizar esta funcionalidad");

                return _default;
            }
            set { _default = value; }
        }
        public Cryptography(string base64SaltKey)
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
