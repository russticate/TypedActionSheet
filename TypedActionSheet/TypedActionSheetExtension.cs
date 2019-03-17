using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TypedActionSheet
{
    public static class TypedActionSheetExtension
    {
        public static async Task<T> DisplayedTypedActionSheet<T>(this Page page, string title, string cancel, string destruction,
            ICollection<T> source, string displayProperty)
        {
            var buttons = source.Select(x => x.GetType()
            .GetProperty(displayProperty)
            .GetValue(x).ToString()).ToArray();

            var selection = await page.DisplayActionSheet(title, cancel, destruction, buttons);

            return !string.IsNullOrWhiteSpace(selection) && selection != cancel ?
                source.FirstOrDefault(x => x.GetType().GetProperty(displayProperty).GetValue(x).ToString() == selection) :
                default(T);
        }
    }
}
