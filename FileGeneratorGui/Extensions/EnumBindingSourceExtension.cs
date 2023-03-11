using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FileGeneratorGui.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }
            if (! enumType.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumType)}: Is not an enum");
            }
            EnumType = enumType;
        }



        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var values = Enum.GetValues(EnumType);

            return values;
        }
    }
}
