﻿using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels
{
    /// <summary>
    /// ViewModel для вывода перечня брендов
    /// </summary>
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
