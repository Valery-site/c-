using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder
{
	internal class BarType
	{
		/// <summary>
		///     Формат сборки штрих-кода
		/// </summary>
		public enum BarcodeType
		{
			/// <summary>
			///     Текстовая информация
			/// </summary>
			Text,
			/// <summary>
			///     Штрих-код
			/// </summary>
			Barcode,
			/// <summary>
			///     Полная информация
			/// </summary>
			Full

		}
	}
}
