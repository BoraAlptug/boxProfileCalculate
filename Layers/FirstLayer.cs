using boxProfileCalculate8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxProfileCalculate8.Layers
{
    public class FirstLayer
    {
        public double maxLenght { get; set; }
        public FirstLayer(double maxLenght)
        {
            this.maxLenght = maxLenght;
        }
        public List<BoxProfile> CreateFirstLayer(List<BoxProfile> requireList)
        {

            List<BoxProfile> boxProfiles = new List<BoxProfile>();

            requireList.Sort((a, b) => b.lenght.CompareTo(a.lenght));

            double downLimit = requireList[0].lenght;
            double jMax = maxLenght / downLimit;
            jMax = (double)Math.Floor(jMax);


            for (int i = 0; i < requireList.Count; i++)
            {
                for (int j = 0; j < jMax; j++)


                    boxProfiles.Add(new BoxProfile()
                    {
                        piece = j + 1,
                        lenght = requireList[i].lenght,
                    });

            }
            return boxProfiles;
        }



    }
}
