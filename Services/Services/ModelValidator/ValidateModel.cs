using Services.BLL.Contracts;
using Services.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Services.ModelValidator
{
    public class ValidateModel<T> :IValidateModel<T> where T : class
    {
        private readonly IUserTranslator _userTranslator;
        #region Singleton
        private readonly static ValidateModel<T> _instance = new();
        public static ValidateModel<T> Current
        {
            get
            {
                return _instance;
            }
        }
        private ValidateModel()
        {
            _userTranslator = UserTranslator.Current;
        }
        #endregion
        public void Validate(T entity)
        {
            ValidationContext v = new ValidationContext(entity);
            List<ValidationResult> r = new List<ValidationResult>();
            if (!Validator.TryValidateObject(entity, v, r, true)) throw new Exception(string.Join(" ", r));
        }

        public void Validate(List<T> list)
        {
            if (list.Count == 0) throw new Exception(_userTranslator.Translate("ErrorFaltanLineas"));
            list.ForEach(x => Validate(x));
        }
    }
}
