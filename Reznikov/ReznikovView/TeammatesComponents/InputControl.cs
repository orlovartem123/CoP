using System;
using System.Windows.Forms;

namespace ReznikovView
{
	public partial class InputControl : UserControl
	{
		public InputControl()
		{
			InitializeComponent();
		}

		public DateTime? FirstDate { get; set; }
		public DateTime? LastDate { get; set; }
		private bool first = true;

		public DateTime value
		{
			set
			{
				if (first)
				{
					first = false;
					return;
				}
				if (!FirstDate.HasValue || !LastDate.HasValue)
                {
					throw new Exception();
				}
				if(value < FirstDate || value > LastDate || FirstDate == LastDate)
				{
					throw new Exception();
				}
				dateTimePicker1.Value = value;
			}

			get
			{
				if (first)
				{
					first = false;
					return dateTimePicker1.Value;
				}
				if (!FirstDate.HasValue || !LastDate.HasValue)
				{
					throw new Exception();
				}
				if (dateTimePicker1.Value < FirstDate || dateTimePicker1.Value > LastDate || FirstDate == LastDate)
				{
					throw new Exception();
				}
				return dateTimePicker1.Value;
			}
		}
	}
}
