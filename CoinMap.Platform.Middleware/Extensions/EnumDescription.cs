using System.ComponentModel;

namespace CoinMap.Platform.Middleware.Extensions
{
    public static class EnumDescription
    {
        public static string ToDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }
    }
}
