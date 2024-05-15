using boxProfileCalculate8.Entities;
using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxProfileCalculate8.Layers
{
    public class CombinationLayer
    {
        public double maxLenght { get; set; }
        public CombinationLayer(double maxLenght)
        {
            this.maxLenght = maxLenght;
        }
        public List<FirstLayerEntity> Combination_fc(List<BoxProfile> res)
        {
            
            List< FirstLayerEntity > firstLayerEntities = new List< FirstLayerEntity >();

            for(int i=1; i< res.Count; i++)
            {
                Combinations<BoxProfile> combinations = new Combinations<BoxProfile>(res, i);
                

                foreach (IList<BoxProfile> c in combinations)
                {
                    FirstLayerEntity firstLayerEntity = new FirstLayerEntity();
                    List<BoxProfile> lis = new List<BoxProfile>();
                    foreach (BoxProfile p in c)
                    {
                       
                        
                        lis.Add(p);
                        firstLayerEntity.profiles=lis;
                        firstLayerEntity.firstLayerSum= firstLayerEntity.firstLayerSum+p.piece*p.lenght;
                        
                    }
                    firstLayerEntities.Add(firstLayerEntity);
                }
                
            }
           

                return firstLayerEntities;

        }

        
    }
}
