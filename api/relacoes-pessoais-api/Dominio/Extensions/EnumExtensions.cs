using System.ComponentModel;

namespace relacoes_pessoais_api.Dominio.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(int value) where T : Enum
        {
            var enumType = typeof(T);
            if (Enum.IsDefined(enumType, value))
            {
                var name = Enum.GetName(enumType, value);
                var field = enumType.GetField(name);
                var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                .FirstOrDefault() as DescriptionAttribute;
                return attr?.Description ?? name;
            }
            return "Unknown";
        }
    }
}
