﻿namespace Entity.Interface
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
