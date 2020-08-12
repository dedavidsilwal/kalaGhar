using System;

namespace KalaGhar.Domain.Exceptions
{
    public class CraftInvalidException : Exception
    {
        public CraftInvalidException(string craftId, Exception ex) : base($"Craft \"{craftId}\" is invalid.", ex)
        {
        }
    }
}
