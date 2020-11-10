using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


/// <summary>
/// Данный интерфейс обязывает экземпляры класса иметь поля для идентификации обьекта
/// </summary>
public interface Identifyable
{
   Id Id { get; }
}
