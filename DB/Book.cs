//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShop.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BooksBasket = new HashSet<BooksBasket>();
            this.Style = new HashSet<Style>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public int YearOfPublish { get; set; }
        public decimal Cost { get; set; }
        public int PagesCount { get; set; }
        public string Image { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BooksBasket> BooksBasket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Style> Style { get; set; }
    }
}