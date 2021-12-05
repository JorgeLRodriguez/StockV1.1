using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Services.ModelValidator
{
    public class ValidateModel<T> :IValidateModel<T> where T : class
    {
        #region "Singleton"
        private static readonly Lazy<IValidateModel<T>> _default = new(() => new ValidateModel<T>());
        public static IValidateModel<T> Current
        {
            get { return _default.Value; }
        }
        #endregion
        public void Validate(T entity)
        {
            ValidationContext v = new(entity);
            List<ValidationResult> r = new();
            if (!Validator.TryValidateObject(entity, v, r, true)) throw new Exception(string.Join(" ", r));
        }

        public void Validate(List<T> list)
        {
            if (list.Count == 0) throw new Exception("ErrorFaltanLineas");
            list.ForEach(x => Validate(x));
        }
    }
}
