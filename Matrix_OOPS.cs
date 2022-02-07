using System;

namespace matrix
{
    class Matrix
    {
        int iRows;
        int iCols;
        int[][] iArray;
        Matrix(int iNo_rows, int iNo_cols)//constructor of class Matrix
        {
            iRows = iNo_rows;
            iCols = iNo_cols;
            iArray = new int[iRows][];
            for (int iRow_no = 0; iRow_no < iCols; iRow_no++)
                iArray[iRow_no] = new int[iCols];

        }
        Matrix()//constructor of class Matrix
        {

            Console.WriteLine("Enter number of rows");
            iRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of columns");

            iCols = Convert.ToInt32(Console.ReadLine());
            iArray = new int[iRows][];
            for (int iRow_no = 0; iRow_no < iCols; iRow_no++)
                iArray[iRow_no] = new int[iCols];
            Console.WriteLine("Enter array elemnt");
            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                    iArray[iRow_no][iColumn_no] = Convert.ToInt32(Console.ReadLine());
        }
        ~Matrix() { }


        public static Matrix operator +(Matrix iMatrix1, Matrix iMatrix2)
        {
            Matrix iAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iRow_no = 0; iRow_no < iMatrix1.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iMatrix1.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = iMatrix1.iArray[iRow_no][iColumn_no] + iMatrix2.iArray[iRow_no][iColumn_no];
            return iAns;
        }


        public static Matrix operator -(Matrix iMatrix1, Matrix iMatrix2)
        {

            Matrix iAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iRow_no = 0; iRow_no < iMatrix1.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iMatrix1.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = iMatrix1.iArray[iRow_no][iColumn_no] - iMatrix2.iArray[iRow_no][iColumn_no];
            return iAns;
        }
        public static Matrix operator *(Matrix iMatrix1, Matrix iMatrix2)
        {

            Matrix iArrayAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iCounter1 = 0; iCounter1 < iMatrix1.iRows; iCounter1++)
            {
                for (int iCounter2 = 0; iCounter2 < iMatrix2.iCols; iCounter2++)
                {
                    iArrayAns.iArray[iCounter1][iCounter2] = 0;
                    for (int iCounter3 = 0; iCounter3 < iMatrix1.iCols; iCounter3++)
                    {
                        iArrayAns.iArray[iCounter1][iCounter2] += iMatrix1.iArray[iCounter1][iCounter3] * iMatrix2.iArray[iCounter3][iCounter2];
                    }
                }
            }
            return iArrayAns;

        }
        public static Matrix operator *(Matrix iMatrix1, int iValue)
        {

            Matrix iAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iRow_no = 0; iRow_no < iMatrix1.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iMatrix1.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = iMatrix1.iArray[iRow_no][iColumn_no] * iValue;
            return iAns;
        }
        void fnDisplay()
        {

            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
            { for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                    Console.Write(iArray[iRow_no][iColumn_no] + "\t");

                Console.WriteLine("");
            }
        }
        public Matrix fnTranspose()
        {

            Matrix iArrayAns = new Matrix(this.iRows, this.iCols);
            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
            {
                for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                    iArrayAns.iArray[iColumn_no][iRow_no] = iArray[iRow_no][iColumn_no];
            }
            return iArrayAns;
        }
        public int this[int iRow_Index, int iColumn_Index]
        {

            // using get accessor
            get
            {
                int iAnswer = iArray[iRow_Index][iColumn_Index];
                return iAnswer;
            }

            // using set accessor
            set
            {
                iArray[iRow_Index][iColumn_Index] = value;
            }
        }
      /*  int operator [][] (int iRow_Index, int iColumn_Index){
            int iAnswer = iArray[iRow_Index][iColumn_Index];
                return iAnswer;
            } */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Matrix clMyobj1=new Matrix();
            Matrix clMyobj2 = new Matrix();
            Matrix clMyobjsum = clMyobj1;
            Matrix clMyobjsub = clMyobj1;
            Matrix clMyobjmul = clMyobj1;
            Matrix clMyobjtranspose = clMyobj1;
            Matrix clMyobjscalermul = clMyobj1;
           // Console.WriteLine("Value of [2][3] of Matrix1"+clMyobj1[2][3]);
            Console.WriteLine("Addition of two Matrix");
            clMyobjsum = clMyobj1 + clMyobj2;
            clMyobjsum.fnDisplay();
            Console.WriteLine();
            Console.WriteLine("Enter the Row index you want to access");
            int iIndex1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Column index you want to access");
            int iIndex2=Convert.ToInt32(Console.ReadLine());
            Console.Write(clMyobj2[iIndex1, iIndex2]);
            Console.WriteLine("Multiplication of two Matrix");
            clMyobjmul = clMyobj1 * clMyobj2;
            clMyobjmul.fnDisplay();
            Console.WriteLine();

            Console.WriteLine("Subtraction of two Matrix");
            clMyobjsub = clMyobj1 - clMyobj2;
            clMyobjsub.fnDisplay();
            Console.WriteLine();

            Console.WriteLine("Transpose of Matrix");
            clMyobjtranspose = clMyobj1.fnTranspose();
            clMyobjtranspose.fnDisplay();
            int iValue = 10;
            Console.WriteLine();

            Console.WriteLine("Scaler Multiplication of Matrix");
            clMyobjscalermul = clMyobj1 * iValue;
            clMyobjscalermul.fnDisplay();
        }

      
    }
}
