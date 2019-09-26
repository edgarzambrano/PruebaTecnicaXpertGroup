using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaTecnicaXpertGroup
{
    public partial class Default : System.Web.UI.Page
    {
        internal long[][][] tree;
        internal long[][][] nums;
        private int dimensions = 0;

        public void generateDimensions(int dimensions)
        {
            if (dimensions == 0)
            {
                return;
            }
            this.dimensions = dimensions;
            tree = RectangularArrays.RectangularLongArray(dimensions + 1, dimensions + 1, dimensions + 1);
            nums = RectangularArrays.RectangularLongArray(dimensions, dimensions, dimensions);
        }

        public virtual void update(int x, int y, int z, int value)
        {
            long delta = value - nums[x][y][z];
            nums[x][y][z] = value;
            for (int i = x + 1; i <= dimensions; i += i & (-i))
            {
                for (int j = y + 1; j <= dimensions; j += j & (-j))
                {
                    for (int k = z + 1; k <= dimensions; k += k & (-k))
                    {
                        tree[i][j][k] += delta;
                    }
                }
            }
        }

        public virtual void query(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            long result = sum(x2 + 1, y2 + 1, z2 + 1) - sum(x1, y1, z1) - sum(x1, y2 + 1, z2 + 1) - sum(x2 + 1, y1, z2 + 1) - sum(x2 + 1, y2 + 1, z1) + sum(x1, y1, z2 + 1) + sum(x1, y2 + 1, z1) + sum(x2 + 1, y1, z1);
            this.resultado.Text += Convert.ToString(result) + "\r\n";
        }

        public virtual long sum(int x, int y, int z)
        {
            long sum = 0l;
            for (int i = x; i > 0; i -= i & (-i))
            {
                for (int j = y; j > 0; j -= j & (-j))
                {
                    for (int k = z; k > 0; k -= k & (-k))
                    {
                        sum += tree[i][j][k];
                    }
                }
            }
            return sum;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonEvaluar_Click(object sender, EventArgs e)
        {
            var lines = this.consulta.Text.Split(new char[] {'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
          
            this.resultado.Text = string.Empty;

            // obtener las dimensiones y el número de operaciones
            string numsLine = Convert.ToString(lines[0]);
            string[] numsLineParts = numsLine.Trim().Split(' ');
            int dimensions = Convert.ToInt32(numsLineParts[0]);
            int numOperations = Convert.ToInt32(numsLineParts[1]);

            // generar las dimensiones del cubo
            this.generateDimensions(dimensions);

            // recorrer el número de operacion
            for (int l = 1; l <= numOperations; l++)
            {
                string line = Convert.ToString(lines[l]);
                string[] lineParts = line.Split(' ');
                // verificar si la operación es de actualización
                if (lineParts[0].Equals("UPDATE"))
                {
                    this.update(Convert.ToInt32(lineParts[1]) - 1, Convert.ToInt32(lineParts[2]) - 1, Convert.ToInt32(lineParts[3]) - 1, Convert.ToInt32(lineParts[4]));
                }
                // verificar si la operación es de consulta
                if (lineParts[0].Equals("QUERY"))
                {
                    this.resultado.Text += line +"\r\n";
                    this.query(Convert.ToInt32(lineParts[1]) - 1, Convert.ToInt32(lineParts[2]) - 1, Convert.ToInt32(lineParts[3]) - 1, Convert.ToInt32(lineParts[4]) - 1, Convert.ToInt32(lineParts[5]) - 1, Convert.ToInt32(lineParts[6]) - 1);
                }
            }

            this.consulta.Text = string.Empty;
        }
    }

    internal static class RectangularArrays
    {
        public static long[][][] RectangularLongArray(int size1, int size2, int size3)
        {
            long[][][] newArray = new long[size1][][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new long[size2][];
                if (size3 > -1)
                {
                    for (int array2 = 0; array2 < size2; array2++)
                    {
                        newArray[array1][array2] = new long[size3];
                    }
                }
            }

            return newArray;
        }
    }
}