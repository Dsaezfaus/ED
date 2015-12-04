using System;
using Gtk;
using System.Diagnostics;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private Random random; 
	private readonly Gdk.Color GREEN_COLOR = new Gdk.Color(0, 255, 0);
	private Table table;
	private List<int> numeros;
	private List<Button> buttons;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		random = new Random ();
		table = new Table (9, 10, true);
		numeros = new List <int> ();
		buttons = new List<Button> ();

		for (uint index = 0; index < 90; index++) {
			uint row = index / 10;
			uint column = index % 10;
			int numero = (int)index + 1;
			numeros.Add (numero);
		}

		table.Visible = true;
		vbox1.Add (table);

		buttonNumero.Clicked += delegate {
			int numero = getNumero();
			show(numero);
			espeak(numero);
			buttonNumero.Sensitive = numeros.Count > 0;
		};

	}
	private int getNumero(){
		int indexAleatorio = random.Next (numeros.Count);
		int numero = numeros[indexAleatorio];
		numeros.RemoveAt(indexAleatorio);
		return numero;
	}
	private void show(int numero) {
		labelNumero.Text = numero.ToString();
		Button button = buttons[numero - 1];
		button.ModifyBg (StateType.Normal, GREEN_COLOR);
	}
	private void espeak (int numero){
		string text = numero.ToString ();
		if (text.Length == 2)
			//text = "\"" + text + " " + text [0] + " " + text [1] + "\"";
			text = string.Format ("\"{0} {1} {2}\"", text, text [0], text [1]);
		Process.Start ("espeak", "-v es " + text);

	}

	private void addButton(int numero, uint row, uint column){
		Button button = new Button ();
		button.Label = numero.ToString ();
		button.Visible = true;
		table.Attach (button, column, column + 1, row, row + 1);
		buttons.Add (button);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}