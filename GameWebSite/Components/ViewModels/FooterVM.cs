using System;
using Microsoft.AspNetCore.Components;

namespace GameWebSite.Components.ViewModels
{
    public class FooterVm : ComponentBase
    {
        protected static string CoyrightStr => $"2020 - {DateTime.Now.Year} © Alex Subbotin";
    }
}