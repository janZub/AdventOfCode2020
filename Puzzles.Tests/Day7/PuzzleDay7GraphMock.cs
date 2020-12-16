using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day7
{
    public class PuzzleDay7GraphMock
    {
        static public Mock<GraphNodeDay7> SetUpGraphMock(Dictionary<string, int> below, string name)
        {
            var moqGraph = new Mock<GraphNodeDay7>();
            moqGraph
               .SetupGet(g => g.ConnectedNodesBelow)
               .Returns(below);

            moqGraph
              .SetupGet(g => g.Name)
              .Returns(name);

            return moqGraph;
        }
    }
}
