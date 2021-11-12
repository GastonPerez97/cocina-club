using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace pw3_proyecto.Filters
{
    public class SkipControllerFilterAttribute : Attribute, IFilterMetadata { }
}
