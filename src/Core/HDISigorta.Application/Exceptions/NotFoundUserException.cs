﻿namespace HDISigorta.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException() 
            //: base("Kullanıcı adı veya şifre hatalıdır...")
        {
        }

        public NotFoundUserException(string? message) : base(message)
        {
        }
    }
}
