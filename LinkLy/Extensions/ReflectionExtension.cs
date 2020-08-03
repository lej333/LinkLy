namespace LinkLy.Extensions
{
    public static class ReflectionExtension
    {
        /// <summary>
        /// Extends reflection object to retrieve property value based on its name.
        /// This helps you to keep code clear.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetPropertyValue<T>(this T item, string propertyName) {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
