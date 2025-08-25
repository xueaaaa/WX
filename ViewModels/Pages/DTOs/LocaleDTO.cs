using System.Globalization;

namespace WX.ViewModels.Pages.DTOs
{
    public class LocaleDTO
    {
        public string NativeName { get; set; }
        public CultureInfo Culture { get; set; }
    }
}
