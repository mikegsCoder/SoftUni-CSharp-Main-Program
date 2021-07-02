using System;

namespace DIContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class Inject : Attribute
    {

    }
}
