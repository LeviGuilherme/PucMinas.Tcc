using System.Collections.Generic;

namespace Shared.DbSimulation.DbExternalSystems
{
    public class Normas
    {
        public Dictionary<int, string> ListaNormas
        {
            get
            {
                return new Dictionary<int, string>(
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Norma#1"),
                        new KeyValuePair<int, string>(2, "Norma#2"),
                        new KeyValuePair<int, string>(3, "Norma#3"),
                        new KeyValuePair<int, string>(4, "Norma#4"),
                        new KeyValuePair<int, string>(5, "Norma#5")
                    }
                );
            }
        }

    }
}
