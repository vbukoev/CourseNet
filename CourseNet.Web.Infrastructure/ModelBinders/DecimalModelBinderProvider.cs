using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CourseNet.Web.Infrastructure.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        // ModelBinderProviderContext is a context object for creating an IModelBinder.
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            // If the context is null, throw an ArgumentNullException.
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            // If the model type is decimal or decimal?, return a new DecimalModelBinder.
            // The DecimalModelBinder is a custom model binder for decimal and decimal? types.
            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null!;
        }
    }
}
