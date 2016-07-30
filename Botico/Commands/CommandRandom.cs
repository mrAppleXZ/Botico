﻿using System;
using PearXLib;

namespace Botico.Commands
{
	public class CommandRandom : ICommand
	{
		public string[] Names(BoticoClient b)
		{
			return b.Loc.GetString("command.random.names").Split(',');
		}

		public string OnUse(CommandArgs args)
		{
			long max, min;
			switch (args.Args.Length)
			{
				default:
					string cmdSymbol = args.Botico.CommandSymbol == null ? "" : args.Botico.CommandSymbol.ToString();
					return args.Botico.Loc.GetString("command.random.usage").Replace("%cmd", cmdSymbol + args.Command);
				case 1:
					if (long.TryParse(args.Args[0], out max))
					{
						return args.Random.NextLong(max).ToString();
					}
					return args.Botico.Loc.GetString("command.random.nan.max");
				case 2:
					if (long.TryParse(args.Args[0], out min))
					{
						if (long.TryParse(args.Args[1], out max))
						{
							if(min <= max)
								return args.Random.NextLong(max, min).ToString();
							return args.Botico.Loc.GetString("command.random.minBiggerMax");
						}
						return args.Botico.Loc.GetString("command.random.nan.max");
					}
					return args.Botico.Loc.GetString("command.random.nan.min");

			}
		}
	}
}
