﻿namespace DDD.Domain.Interfaces.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }  
}
