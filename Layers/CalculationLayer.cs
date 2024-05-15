using boxProfileCalculate8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxProfileCalculate8.Layers
{
    public class CalculationLayer
    {
        public double maxLenght { get; set; }
        public CalculationLayer(double maxLenght)
        {
            this.maxLenght = maxLenght;
        }
        public List<FirstLayerEntity> RemoveUpMaxLenght(List<FirstLayerEntity> firstLayerEntities)
        {
            firstLayerEntities.Sort((x,y)=>y.firstLayerSum.CompareTo(x.firstLayerSum));
            List<FirstLayerEntity> temp= new List<FirstLayerEntity>();
            temp.AddRange(firstLayerEntities);


            foreach (FirstLayerEntity entity in temp)
            {
                if (entity.firstLayerSum> maxLenght)
                {
                    firstLayerEntities.Remove(entity);
                }
            }



            return firstLayerEntities;
             
        }

        public List<FirstLayerEntity> RemoveDuplicateCom(List<FirstLayerEntity> list)
        {
            List<FirstLayerEntity> remove= new List<FirstLayerEntity>();
            remove.AddRange(list);
            
            foreach (FirstLayerEntity entity in list)
            {
                var res=  entity.profiles
                                //.GroupBy(x => x.lenght) // lenght özelliğine göre gruplama yap
                                //.Where(g => g.Count() == 1) // grup içinde tekil olanları seç
                                //.SelectMany(g => g.ToList()) // seçilenleri tek bir liste haline getir
                                .Select(x=>x.lenght)
                                .Distinct()
                                
                                .ToList();
                if (res.Count != entity.profiles.Count)
                {
                    remove.Remove(entity);
                }


            }



            return remove;
        }
    }
}
