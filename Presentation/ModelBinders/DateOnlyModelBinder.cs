using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Presentation.ModelBinders;

public class DateOnlyModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
            throw new ArgumentNullException(nameof(bindingContext));
        var modelName = bindingContext.ModelName;
        var valueProvideResult = bindingContext.ValueProvider.GetValue(modelName);
        if(valueProvideResult == ValueProviderResult.None)
            return Task.CompletedTask;
        
        bindingContext.ModelState.SetModelValue(modelName,valueProvideResult);
        var dateStr = valueProvideResult.FirstValue;
        if (!DateOnly.TryParseExact(dateStr, "dd.MM.yyyy", new CultureInfo("tr-TR"), DateTimeStyles.None, out DateOnly date))
        {
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "DateTime should be in format 'dd.MM.yyyy'");
            return Task.CompletedTask;
        }
        bindingContext.Result = ModelBindingResult.Success(date);
        return Task.CompletedTask;
    }
    
}