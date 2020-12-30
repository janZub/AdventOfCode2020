using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day23
{
    public class CoralGameDay23
    {
        private int skippedElements = 3;
        public Dictionary<int, Tuple<int, int>> NumbersWithConnections { get; set; }
        public int TargetNumber { get; set; }
        public List<Tuple<int, Tuple<int, int>>> ElementsUp { get; set; }
        public int DestinationNumber { get; set; }

        public CoralGameDay23()
        {
            NumbersWithConnections = new Dictionary<int, Tuple<int, int>>();
            ElementsUp = new List<Tuple<int, Tuple<int, int>>>();
        }

        public void PutElementsUp()
        {
            var nextToPutUp = NumbersWithConnections[TargetNumber].Item2;
            for (int i = 0; i < skippedElements; i++)
            {
                var elementToPutUp = NumbersWithConnections[nextToPutUp];
                NumbersWithConnections.Remove(nextToPutUp);
                ElementsUp.Add(new Tuple<int, Tuple<int, int>>(nextToPutUp, elementToPutUp));
                nextToPutUp = elementToPutUp.Item2;
            }
        }
    
        public void RestoreLinksForCollection()
        {
            RestoreTargetLinks();
            RestoreElementAfterTargetLinks();
        }
        private void RestoreTargetLinks()
        {
            var targetLinks = NumbersWithConnections[TargetNumber];
            var lastUp = ElementsUp.Last();
            var newTargetLinks = new Tuple<int, int>(targetLinks.Item1, lastUp.Item2.Item2);
            
            NumbersWithConnections[TargetNumber] = newTargetLinks;
        }
        private void RestoreElementAfterTargetLinks()
        {
            var elementAfterTarget = NumbersWithConnections[TargetNumber].Item2;
            var elementAfterTargetLinks = NumbersWithConnections[elementAfterTarget];
            var newElementAfterTargetLinks = new Tuple<int, int>(TargetNumber, elementAfterTargetLinks.Item2);

            NumbersWithConnections[elementAfterTarget] = newElementAfterTargetLinks;
        }

        public void SetDestination()
        {
            var localTarget = TargetNumber - 1;
            for (; localTarget > 0; localTarget--)
            {
                if (NumbersWithConnections.ContainsKey(localTarget))
                {
                    DestinationNumber = localTarget;
                    return;
                }
            }
            DestinationNumber = NumbersWithConnections.Max(k => k.Key);
        }

        public void PutDownElements()
        {
            var destinationNext = NumbersWithConnections[DestinationNumber].Item2;

            RestoreDestinationLinks();
            RestoreLinksOriginalDestinationNextElement(destinationNext);
            PutDownRestOfTheElements();
            EmptyElementsUp();
        }
   
        private void RestoreDestinationLinks()
        {
            var firstUp = ElementsUp.First();
            var destinationLinks = NumbersWithConnections[DestinationNumber];

            if (ElementsUp.Last().Item1 == destinationLinks.Item1)
                destinationLinks = new Tuple<int, int>(firstUp.Item2.Item1, destinationLinks.Item2);

            NumbersWithConnections.Add(firstUp.Item1, new Tuple<int, int>(DestinationNumber, firstUp.Item2.Item2));
            NumbersWithConnections[DestinationNumber] = new Tuple<int, int>(destinationLinks.Item1, firstUp.Item1);
        }
        private void RestoreLinksOriginalDestinationNextElement(int originalNextDestination)
        {
            var lastUp = ElementsUp.Last();
            var destinationNextLinks = NumbersWithConnections[originalNextDestination];

            NumbersWithConnections.Add(lastUp.Item1, new Tuple<int, int>(lastUp.Item2.Item1, originalNextDestination));
            NumbersWithConnections[originalNextDestination] = new Tuple<int, int>(lastUp.Item1, destinationNextLinks.Item2);
        }
        private void PutDownRestOfTheElements()
        {
            foreach (var el in ElementsUp.Skip(1).SkipLast(1).ToList())
                NumbersWithConnections.Add(el.Item1, el.Item2);
        }
        private void EmptyElementsUp()
        {
            ElementsUp = new List<Tuple<int, Tuple<int, int>>>();
        }

        public void SetNewTarget()
        {
            TargetNumber = NumbersWithConnections[TargetNumber].Item2;
        }
    }
}