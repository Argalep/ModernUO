using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Server.Utilities;

namespace Server.Factions
{
    public class Reflector
    {
        private static List<Town> m_Towns;

        private static List<Faction> m_Factions;

        public static List<Town> Towns
        {
            get
            {
                if (m_Towns == null)
                    ProcessTypes();

                return m_Towns;
            }
        }

        public static List<Faction> Factions
        {
            get
            {
                if (m_Factions == null)
                    ProcessTypes();

                return m_Factions;
            }
        }

        private static object Construct(Type type)
        {
            try
            {
                return ActivatorUtil.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

        private static void ProcessTypes()
        {
            m_Factions = new List<Faction>();
            m_Towns = new List<Town>();

            Assembly[] asms = AssemblyHandler.Assemblies;

            for (int i = 0; i < asms.Length; ++i)
            {
                Assembly asm = asms[i];
                TypeCache tc = AssemblyHandler.GetTypeCache(asm);
                Type[] types = tc.Types.ToArray();

                for (int j = 0; j < types.Length; ++j)
                {
                    Type type = types[j];

                    if (type.IsSubclassOf(typeof(Faction)))
                    {
                        if (Construct(type) is Faction faction)
                            Faction.Factions.Add(faction);
                    }
                    else if (type.IsSubclassOf(typeof(Town)))
                    {
                        if (Construct(type) is Town town)
                            Town.Towns.Add(town);
                    }
                }
            }
        }
    }
}
