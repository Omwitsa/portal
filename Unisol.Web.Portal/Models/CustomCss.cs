using System.ComponentModel;
using System.Drawing;

namespace Unisol.Web.Portal.Models
{
    public class CustomCss
    {
        private const string Css = @"
		body[themebg-pattern = ""theme1""] {
			background-color: @primary@ !important;
		}
		.pcoded .pcoded-header[header-theme=""theme1""] {
			background: @primary@ !important;
		}
		.btn-primary { 
			background-color: @primary@; 
		}
		.table-primary, .table-primary > td, .table-primary > th {
			background-color: @primary@ !important;;
		}
		.pcoded.pcoded-header[header-theme = ""theme1 ""] {
			background: @primary@ !important;;
		}
		.pcoded[fream-type=""theme1""][theme-layout=""vertical""] .page-header {
			background: @primary@ !important;
		}
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li.active>a, 
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li.active:hover>a, 
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li.pcoded-trigger>a, 
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li.pcoded-trigger:hover>a, 
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li:hover>a, 
		.pcoded[theme-layout=""vertical""] .pcoded-navbar[active-item-theme=""theme1""] .pcoded-item>li:hover:hover>a {
			background: @primary@ !important;
			color: #fff;
		}
		.badge-primary {
			background: @primary@ !important;
		}
		.input-group-append .input-group-text, 
		.input-group-prepend .input-group-text {
			background-color: @primary@ !important;
			border-color: @primary@ !important;
		}
		.btn-primary,
		.sweet-alert button.confirm,
		.wizard>.actions a {
			background-color: @primary@ !important;
			border-color: @primary@ !important;
		}
		.page-item.active .page-link {
			background-color: @primary@ !important;
			border-color: @primary@ !important;
		}
		.pcoded .pcoded-navbar .pcoded-navigation-label[menu-title-theme=""theme1""] {
			color: @primary@ !important;
		}

		.nav-tabs .slide { 
			background: @primary@ !important;
		}
		.md-tabs .nav-item.open .nav-link, 
		.md-tabs .nav-item.open .nav-link:focus, 
		.md-tabs .nav-item.open .nav-link:hover, 
		.md-tabs .nav-link.active, 
		.md-tabs .nav-link.active:focus, 
		.md-tabs .nav-link.active:hover {
			color:  @primary@ !important;
		}
		.wizard > .steps .current a,
		.wizard > .steps .current a:hover,
		.wizard > .steps .current a:active {
		  background: @primary@ !important;
		}
		.wizard > .steps .done a,
		.wizard > .steps .done a:hover,
		.wizard > .steps .done a:active {
		  background: @primaryLight@ !important;
		}
		#design-wizard .steps li:after {
			background: @primary@ !important;
		}
		.btn-outline-primary {
			border-color: @primary@ !important;
			color: @primary@ !important;
			background-color: #fff;
		}
	";

        public static string GenerateStyle(string primaryColor, string secondaryColor)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Color));
            var sec = secondaryColor == null ? primaryColor : secondaryColor;
            var primary = (Color)converter.ConvertFromString(primaryColor);
            var secondary = (Color)converter.ConvertFromString(sec);

            var primaryDark = ChangeColorBrightness(primary, (float)-0.2);
            var primaryLight = ChangeColorBrightness(primary, (float)0.5);

            var secondaryDark = ChangeColorBrightness(secondary, 1);
            var secondaryLight = ChangeColorBrightness(secondary, -1);

            return Css
                .Replace("@primary@", AsHex(primary))
                .Replace("@secondary@", AsHex(secondary))
                .Replace("@primaryDark@", AsHex(primaryDark))
                .Replace("@primaryLight@", AsHex(primaryLight))
                .Replace("@secondaryDark@", AsHex(secondaryDark))
                .Replace("@secondaryLight@", AsHex(secondaryLight));
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = color.R;
            float green = color.G;
            float blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private static string AsHex(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}