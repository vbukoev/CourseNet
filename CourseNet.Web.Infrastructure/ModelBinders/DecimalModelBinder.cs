using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CourseNet.Web.Infrastructure.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None && string.IsNullOrWhiteSpace(valueProviderResult.FirstValue))
            {
                decimal parsedValue = 0m;

                bool binderSucceed = false;

                try
                {
                    string formDecimalValue = valueProviderResult.FirstValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    formDecimalValue = formDecimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDecimal(formDecimalValue);

                    binderSucceed = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (binderSucceed)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
