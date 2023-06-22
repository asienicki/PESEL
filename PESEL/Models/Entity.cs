using System;

namespace PESEL.Models
{
    [Obsolete("Use PeselEntity instead of Entity")]
    public class Entity : PeselEntity
    {
        public Entity(string peselString) : base(peselString)
        {
        }
    }
}