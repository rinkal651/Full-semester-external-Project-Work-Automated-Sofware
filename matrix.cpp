#include<iostream>
using namespace std;
class Matrix
{
    public:
        int iRows;
        int iCols;
        int** iArray;
        Matrix(int iNo_rows, int iNo_cols)//constructor of class Matrix
        {
            iRows = iNo_rows;
            iCols = iNo_cols;
              int **iArray= new int * [iRows];
        for (int iRow_no = 0; iRow_no < iRows; iRow_no++) {
            iArray[iRow_no] = new int[iCols];
  }


        }
        Matrix()//constructor of class Matrix
        {

            cout<<"Enter number of rows";
            cin>>iRows;
         cout<<"Enter number of columns";
            cin>>iCols;
               int **iArray= new int * [iRows];
        for (int iRow_no = 0; iRow_no < iRows; iRow_no++) {
            iArray[iRow_no] = new int[iCols];
  }
            cout<<"Enter array elemnt";
            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                    cin>>iArray[iRow_no][iColumn_no];
        }
        ~Matrix() { }


        Matrix operator +(Matrix iMatrix1)
        {
            Matrix ** iAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iRow_no = 0; iRow_no < iMatrix1.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iMatrix1.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = iMatrix1.iArray[iRow_no][iColumn_no] + this.iArray[iRow_no][iColumn_no];
            return iAns;
        }


        Matrix operator -(Matrix iMatrix1)
        {

            Matrix iAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iRow_no = 0; iRow_no < iMatrix1.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < iMatrix1.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = this.iArray[iRow_no][iColumn_no] - iMatrix1.iArray[iRow_no][iColumn_no];
            return iAns;
        }
         Matrix operator *(Matrix iMatrix1)
        {

            Matrix iArrayAns = new Matrix(iMatrix1.iRows, iMatrix1.iCols);
            for (int iCounter1 = 0; iCounter1 < this.iRows; iCounter1++)
            {
                for (int iCounter2 = 0; iCounter2 < iMatrix1.iCols; iCounter2++)
                {
                    iArrayAns.iArray[iCounter1][iCounter2] = 0;
                    for (int iCounter3 = 0; iCounter3 < this.iCols; iCounter3++)
                    {
                        iArrayAns.iArray[iCounter1][iCounter2] += this.iArray[iCounter1][iCounter3] * iMatrix1.iArray[iCounter3][iCounter2];
                    }
                }
            }
            return iArrayAns;

        }
        Matrix operator *(int iValue)
        {

            Matrix iAns = new Matrix(this.iRows,this.iCols);
            for (int iRow_no = 0; iRow_no < this.iRows; iRow_no++)
                for (int iColumn_no = 0; iColumn_no < this.iCols; iColumn_no++)
                    iAns.iArray[iRow_no][iColumn_no] = this.iArray[iRow_no][iColumn_no] * iValue;
            return iAns;
        }
        void fnDisplay()
        {

            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
            { for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                   cout<<iArray[iRow_no][iColumn_no]<< "\t";

               cout<<"";
            }
        }
       Matrix fnTranspose()
        {

            Matrix iArrayAns = new Matrix(this.iRows, this.iCols);
            for (int iRow_no = 0; iRow_no < iRows; iRow_no++)
            {
                for (int iColumn_no = 0; iColumn_no < iCols; iColumn_no++)
                    iArrayAns.iArray[iColumn_no][iRow_no] = iArray[iRow_no][iColumn_no];
            }
            return iArrayAns;
        }

         int * & operator [] (const int &iRow_Index){
            int iAnswer = iArray[iRow_Index];
                return iAnswer;
            }
};
       int Main()
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
            cout<<"Addition of two Matrix";
            clMyobjsum = clMyobj1 + clMyobj2;
            clMyobjsum.fnDisplay();
            cout<<"\n";
            cout<<"Enter the Row index you want to access";
            int iIndex1=Convert.ToInt32(Console.ReadLine());
            cout<<"Enter the Column index you want to access";
            int iIndex2=Convert.ToInt32(Console.ReadLine());
           cout<<clMyobj2[iIndex1, iIndex2];
            cout<<"Multiplication of two Matrix";
            clMyobjmul = clMyobj1 * clMyobj2;
            clMyobjmul.fnDisplay();
           cout<<"Subtraction of two Matrix";
            clMyobjsub = clMyobj1 - clMyobj2;
            clMyobjsub.fnDisplay();
           cout<<"Transpose of Matrix";
            clMyobjtranspose = clMyobj1.fnTranspose();
            clMyobjtranspose.fnDisplay();
            int iValue = 10;
            cout<<"Scaler Multiplication of Matrix";
            clMyobjscalermul = clMyobj1 * iValue;
            clMyobjscalermul.fnDisplay();
            return 0;
        }

