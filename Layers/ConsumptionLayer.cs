using boxProfileCalculate8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxProfileCalculate8.Layers
{
    public class ConsumptionLayer
    {
        public double CalculateConsupmtionCountForCombination(List<BoxProfile> requireList, List<BoxProfile> combination)
        {


            List<double> doubles = new List<double>();

            foreach (BoxProfile require in requireList)
            {
                foreach (BoxProfile boxProfile in combination)
                {
                    if (require.lenght == boxProfile.lenght)
                    {
                        doubles.Add(require.piece / boxProfile.piece);
                    }
                }
            }
            doubles.Sort();
            return doubles[0];
        }

        public List<BoxProfile> AddOrdersList(List<BoxProfile> ordersLists, List<BoxProfile> selectedCombination, double consuptionCount)
        {
            foreach (BoxProfile orders in ordersLists)
            {
                foreach (BoxProfile selected in selectedCombination)
                {
                    if (selected.lenght == orders.lenght)
                    {
                        orders.piece = orders.piece + selected.piece * consuptionCount;
                    }
                }
            }

            return ordersLists;
        }

        public List<BoxProfile> NewRequireList(List<BoxProfile> requireList, FirstLayerEntity selectedCombination, double consumptionCount)
        {
            List<BoxProfile> newRequireList = new List<BoxProfile>();


            foreach(BoxProfile require in requireList)
            {
                foreach(BoxProfile selected in selectedCombination.profiles)
                {
                    if(require.lenght == selected.lenght)
                    {
                        require.piece=require.piece-selected.piece* consumptionCount;
                    }
                }
            }
            newRequireList.AddRange(requireList);

            foreach (BoxProfile require in requireList)
            {
                if(require.piece == 0)
                {
                    newRequireList.Remove(require);
                }
            }
            return newRequireList;
        }
    }
}
