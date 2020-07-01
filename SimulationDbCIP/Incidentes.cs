using System.Collections.Generic;

namespace Shared.DbSimulation.DbCIP
{
    public class Incidentes
    {
        public Dictionary<int, string> ListaIncidentes
        {
            get
            {
                return new Dictionary<int, string>(
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>(1, "Incidente#1"),
                        new KeyValuePair<int, string>(2, "Incidente#2"),
                        new KeyValuePair<int, string>(3, "Incidente#3"),
                        new KeyValuePair<int, string>(4, "Incidente#4"),
                        new KeyValuePair<int, string>(5, "Incidente#5")
                    }
                );
            }
        }
    }
}
