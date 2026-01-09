using System;

namespace PESEL.Models
{
    public struct Pesel
    {
        /// <summary>
        /// 6 pierwszych cyfr
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Cyfry z pozycji 7,8,9 z numeru pesel
        /// </summary>
        public char[] RandomNumbers { get; set; }

        /// <summary>
        /// 10 cyfra numeru pesel
        /// </summary>
        public byte GenderNumber { get; set; }

        /// <summary>
        /// 11 cyfra numeru pesel
        /// </summary>
        public byte ControlNumber { get; set; }

        /// <summary>
        /// Informacja wynikająca z ostatniej cyfry
        /// </summary>
        public Gender Gender => GenderNumber % 2 == 0 ? Gender.Woman : Gender.Man;
    }
}