﻿using System;
using System.Globalization;
using System.Web.Mvc;

namespace Ris.AgencijskeVesti.DataBinders
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);

            return date;
        }
    } 
}