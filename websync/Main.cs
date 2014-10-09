using System;
using System.Collections.Generic;
using FM.WebSync;
using FM;

namespace websync
{
	class MainClass
	{
		private static bool showJson = false;

		public static void Main (string[] args)
		{

			var url = "<url>";
			var channel = "<channel>";
			var count = 0;


			if(args.Length >= 1)
				url = string.Format("https://{0}/websync/websync.ashx",args[0]);

			var client = new Client (url);
			client.Synchronous = true;


			WriteLine (Category.None, "Press {Enter} to exit...");
			WriteLine (Category.Warn, "Connecting to websync service...");

			client.Connect (new ConnectArgs{
				OnSuccess = (e)=> WriteLine(Category.Success, "Connection succedded."),
				OnFailure=(e)=> WriteLine(Category.Error,"Could not connnect to websync service.")
			});

			if (client.IsConnected) {
				client.Subscribe (new SubscribeArgs (channel){
					OnSuccess=(e)=> WriteLine(Category.Success, "Subscribed to the fx channel."),
					OnFailure=(e)=> WriteLine(Category.Error, "Could not connnect to fx channel."),
					OnReceive=(e)=> {
						count += 1;
						Write(Category.None,  DateTime.Now.ToString("[hh:mm:ss:fff] "));
						var operacion = Json.Deserialize<Operacion>(e.DataJson);
						if(!showJson)
							WriteLine(Category.Info, string.Format("{0} {1,7} {2} {3,-3} {4}-{5} {6,6} {7,2} - notas:{8}",
							                                       operacion.IdPortafolio,
							                                       operacion.IdOperacion,
							                                       operacion.FechaOperacion,
							                                       operacion.TipoOperacion,
							                                       operacion.IdDivisaBase,
							                                       operacion.IdDivisaOperada,
							                                       operacion.IdCliente,
							                                       operacion.IdUnidadNegocio,
							                                       operacion.Notas));
						else
							WriteLine(Category.Info, e.DataJson);
					}
				});
			}

			var input = string.Empty;
			do{
				input = Console.ReadLine ();
				if(input.ToLower().Contains("json"))
					showJson = !showJson;
				if(input.ToLower().Contains("count"))
					WriteLine(Category.Warn, string.Format("total de mensajes: {0}", count));
			} while(!string.IsNullOrEmpty(input));

			client.Disconnect ();

		}

		private static void Write (Category category, string message, ConsoleColor endColor = ConsoleColor.White)
		{
			Colorize (category);
			Console.Write (message);
			Console.ForegroundColor = endColor;
		}

		private static void WriteLine (Category category, string message, ConsoleColor endColor = ConsoleColor.White)
		{
			Colorize (category);
			Console.WriteLine (message);
			Console.ForegroundColor = endColor;
		}

		private static void Colorize (Category category)
		{
			switch (category) {
			case Category.None:
				Console.ForegroundColor = ConsoleColor.White;
				break;
			case Category.Error:
				Console.ForegroundColor = ConsoleColor.Red;
				break;
			case Category.Warn:
				Console.ForegroundColor = ConsoleColor.Yellow;
				break;
			case Category.Success:
				Console.ForegroundColor = ConsoleColor.Green;
				break;
			case Category.Info:
				Console.ForegroundColor = ConsoleColor.Cyan;
				break;
			}
		}

		public enum Category
		{
			None,
			Info,
			Warn,
			Error,
			Success
		}
	}
}
