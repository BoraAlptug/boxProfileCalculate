using boxProfileCalculate8.Calculation;
using boxProfileCalculate8.Entities;
using boxProfileCalculate8.Layers;

namespace boxProfileCalculate2
{
    class Program
    {
        public static int[] lenghts = { 2345, 1995, 1495, 1745, 1345 };
        public static int[] pieces = { 40, 220, 170, 20, 40 };
        public static int[,] profilesArray = { { 2345, 40 }, { 1995, 220 }, { 1495, 170 }, { 1745, 20 }, { 1345, 40 } };
        public static int[,] comProfilesArray = { { 2345, 1 }, { 1995, 1 }, { 1495, 1 }, { 1745, 1 }, { 1345, 1 } };
        public static double maxLenght = 6000;
        static void Main()
        {
            EntityConvertion entityConvertion = new EntityConvertion();

            List<BoxProfile> requireList = entityConvertion.RequireList(profilesArray);
            List<BoxProfile> ordersLists = entityConvertion.CreateOrdersList(profilesArray);
            List<ResultEntity> resultList = new List<ResultEntity>();

            //-->loop area start
            while (requireList.Count > 0)
            {
                FirstLayer firstLayer = new FirstLayer(maxLenght);

                var firstLayerEnty = firstLayer.CreateFirstLayer(requireList);

                CombinationLayer combinationLayer = new CombinationLayer(maxLenght);

                var combinationList = combinationLayer.Combination_fc(firstLayerEnty);

                CalculationLayer calculationLayer = new CalculationLayer(maxLenght);

                var combinationRemovedUpLenghtList = calculationLayer.RemoveUpMaxLenght(combinationList);

                var combinationRemovedDuplicatedList = calculationLayer.RemoveDuplicateCom(combinationRemovedUpLenghtList);

                ConsumptionLayer consumptionLayer = new ConsumptionLayer();

                List<BoxProfile> selectedCombinationList = combinationRemovedDuplicatedList[0].profiles;

                double consumptionCount = consumptionLayer.CalculateConsupmtionCountForCombination(requireList, selectedCombinationList);

                ordersLists = consumptionLayer.AddOrdersList(ordersLists, selectedCombinationList, consumptionCount);

                var selectedCombination = combinationRemovedDuplicatedList[0];

                ResultEntity resultEntity = entityConvertion.ResultEntityConversation(selectedCombination, consumptionCount);

                resultList.Add(resultEntity);

                requireList = consumptionLayer.NewRequireList(requireList, selectedCombination, consumptionCount);
            }
            double a = 0;
            foreach(var res in resultList)
            {
                a = a + res.selectedCount;
                string tempStrin = "";
                foreach(var res2 in res.profiles)
                {
                    tempStrin = res2.piece + "x" + res2.lenght+" + "+tempStrin;
                }
                tempStrin = tempStrin + "=" + res.firstLayerSum + " adet=" + Math.Ceiling(res.selectedCount) + "   --->Fire="+(maxLenght-res.firstLayerSum);
                Console.WriteLine(tempStrin);
            }
            Console.WriteLine("Toplam ="+(a=Math.Ceiling(a))+" Profil uzunluğu="+maxLenght);
            Console.ReadLine();
        }
    }
}






