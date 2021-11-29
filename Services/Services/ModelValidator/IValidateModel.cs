using System.Collections.Generic;

namespace Services.Services.ModelValidator
{
    public interface IValidateModel<T>
    {
        void Validate(T entity);
        void Validate(List<T> list);
    }
}
