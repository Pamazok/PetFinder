using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFinder.Code
{
    public class Functions
    {
        public static KeyValuePair<int, int> NewPicturesSize(int real_width, int real_height, int max_width, int max_height)
        {
            int new_width = 0;
            int new_height = 0;
            if (real_width >= real_height)
            {
                new_width = max_width;
                new_height = (int)((float)real_height * ((float)max_width / (float)real_width));
            }
            else
            {
                new_height = max_height;
                new_width = (int)((float)real_width * ((float)max_height / (float)real_height));
            }
            return new KeyValuePair<int, int>(new_width, new_height);
        }
    }
}