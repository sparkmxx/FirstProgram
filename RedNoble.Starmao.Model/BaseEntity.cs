using System;
using System.ComponentModel.DataAnnotations;

namespace RedNoble.Starmao.Model
{
    public abstract class BaseEntity<T>
    {
        protected BaseEntity()
        {
            AddDate = DateTime.Now;
            SortRank = 0;
            IsDelete = false;
        }

        [Key]
        public T Id { get; set; }

        public DateTime AddDate { get; set; }

        public int SortRank { get; set; }

        public bool IsDelete { get; set; }
    }
}
