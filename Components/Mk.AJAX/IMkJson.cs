using System;

namespace Mk.AJAX
{
    public interface IMkJson
    {
        string Serialize(object value);

        object Deserialize(string value, Type type);
    }
}