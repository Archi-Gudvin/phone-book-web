using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phone_book.Models
{
    /// <summary>
    /// Перечисление полей для сортировки
    /// </summary>
    public enum SortState
    {
        LastNameAsc,
        LastNameDesc,
        FirstNameAsc,
        FirstNameDesc,
        PatronymicAsc,
        PatronymicDesc,
    }
}
