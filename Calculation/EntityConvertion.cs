using boxProfileCalculate8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxProfileCalculate8.Calculation
{
    public  class EntityConvertion
    {
        public List<BoxProfile> RequireList(int[,] requires)
        {
            List<BoxProfile> list = new List<BoxProfile> ();
            for(int i = 0; i < requires.GetLength(0); i++)
            {
                list.Add(new BoxProfile()
                {
                    lenght = requires[i,0],
                    piece = requires[i,1]
                });
            }
            return list;
        }

        public List<BoxProfile> CreateOrdersList(int[,] requires)
        {
            List<BoxProfile> list = new List<BoxProfile>();

            for(int i = 0; i <  requires.GetLength(0); i++)
            {
                list.Add(new BoxProfile()
                {
                    lenght = requires[i, 0],
                    piece = 0
                });  
            }

            return list;
        }

        public ResultEntity ResultEntityConversation(FirstLayerEntity selectedCombination, double consuptionCount)
        {
            ResultEntity entity=new ResultEntity();
            entity.profiles=selectedCombination.profiles;
            entity.firstLayerSum= selectedCombination.firstLayerSum;
            entity.selectedCount = consuptionCount;

            return entity;
        }
    }
}
