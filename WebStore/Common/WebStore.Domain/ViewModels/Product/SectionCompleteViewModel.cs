using System.Collections.Generic;
using WebStore.Domain.ViewModels.Product;

namespace WebStore.Domain.ViewModels
{
    public class SectionCompleteViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }

        public int? CurrentParrentSectionId { get; set; }

        public int? CurrentSectionId { get; set; }
    }
}