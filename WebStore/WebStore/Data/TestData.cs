﻿using System;
using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
                 new Employee(){ Id = 1, Age = 23, Department="Отдел № 1", Email="ges@example.com", SurName = "Гусев", FirstName = "Ефрем", Patronymic = "Степановна"       ,BirthDay = new DateTime(2000,01,21), DateOfEmployment = new DateTime(2020,03,01)}
                ,new Employee(){ Id = 2, Age = 34, Department="Отдел № 1", Email="akp@example.com", SurName = "Акимова ", FirstName = "Кристина ", Patronymic = "Петрович"  ,BirthDay = new DateTime(2000,04,14), DateOfEmployment = new DateTime(2020,03,02)}
                ,new Employee(){ Id = 3, Age = 45, Department="Отдел № 2", Email="jvd@example.com", SurName = "Жгулёв", FirstName = "Владилен", Patronymic = "Дмитриевич"   ,BirthDay = new DateTime(2000,02,27), DateOfEmployment = new DateTime(2020,02,04)}
                ,new Employee(){ Id = 4, Age = 32, Department="Отдел № 3", Email="snf@example.com", SurName = "Сонина ", FirstName = "Надежда", Patronymic = "Феликсовна"   ,BirthDay = new DateTime(2000,05,05), DateOfEmployment = new DateTime(2020,02,09)}
        };
    };
}