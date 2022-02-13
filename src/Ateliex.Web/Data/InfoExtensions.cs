using Ateliex.Data;

namespace Ateliex.Extensions;

public static class InfoExtensions
{
    public static bool IsNew(this Entity model)
    {
        return model.Id == 0;
    }

    public static string GetTypeName(this Entity model)
    {
        var dataEntityType = model.GetType();

        return dataEntityType.Name;
    }

    public static string GetTypeName(this IEnumerable<Entity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        return dataEntityType.Name;
    }

    public static InfoAttribute GetInfo(this Entity model)
    {
        var dataEntityType = model.GetType();

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(InfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (InfoAttribute)dataInfoAttributes[0];

        return info;
    }

    public static InfoAttribute GetInfo(this IEnumerable<Entity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(InfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (InfoAttribute)dataInfoAttributes[0];

        return info;
    }
}