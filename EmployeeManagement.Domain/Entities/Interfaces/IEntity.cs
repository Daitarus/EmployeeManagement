﻿namespace EmployeeManagement.Domain.Entities.Interfaces
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
