using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    class AngleDOWN : Figure
    {
        public AngleDOWN(Tetris tetris) : base(tetris)
        {
            map = new int[sizeMap, sizeMap] { { 0, 1, 0, 0 },
                                              { 0, 1, 0, 0 },
                                              { 1, 1, 0, 0 },
                                              { 0, 0, 0, 0 } };
        }
    }
}
