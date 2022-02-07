#include <iostream>
#include <cstring>
using namespace std;

class Matrix
{
private:
    int i_Row, i_Column;
    int **iArray;

public:
    Matrix(int iaRow, int iaColumn, bool isInput) : i_Row(iaRow), i_Column(iaColumn)
    {
        iArray = new int *[i_Row];
         for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++) {
            iArray[iRowIndex] = new int[i_Column];
  }


        if (isInput)
        {

            cout << "Enter Value for Matrix\n";
            for (int iRowIndex = 0; iRowIndex < iaRow; iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < iaColumn; iColIndex++)
                {
                    cin >> iArray[iRowIndex][iColIndex];
                }
            }
        }
        else
        {
            for (int iRowIndex = 0; iRowIndex < iaRow; iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < iaColumn; iColIndex++)
                {
                    iArray[iRowIndex][iColIndex] = 0;
                }
            }
        }
    }

     Matrix operator+(const Matrix &claObjM2)
    {
        Matrix clAns = Matrix(i_Row, i_Column, false);
        for (int iRowIndex = 0; iRowIndex < i_Row; ++iRowIndex)
        {
            for (int iColIndex = 0; iColIndex < i_Column; ++iColIndex)
            {
                clAns.iArray[iRowIndex][iColIndex] = iArray[iRowIndex][iColIndex] + claObjM2.iArray[iRowIndex][iColIndex];
            }
        }
        return clAns;
    }
      Matrix operator-(const Matrix &claObjM2)
    {
        Matrix clAns = Matrix(i_Row, i_Column, false);
        for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++)
        {
            for (int iColIndex = 0; iColIndex < i_Column; iColIndex++)
            {
                clAns.iArray[iRowIndex][iColIndex] = iArray[iRowIndex][iColIndex] - claObjM2.iArray[iRowIndex][iColIndex];
            }
        }
        return clAns;
    }
     Matrix operator*(const Matrix &claObjM2)
    {
        Matrix clAns = Matrix(i_Row, i_Column, false);
        for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < claObjM2.i_Column; iColIndex++)
                {
                    clAns.iArray[iRowIndex][iColIndex] = 0;
                    for (int iCounter= 0; iCounter < i_Column; iCounter++)
                    {
                        clAns.iArray[iRowIndex][iColIndex] += iArray[iRowIndex][iCounter] * claObjM2.iArray[iCounter][iColIndex];
                    }
                }
            }
        return clAns;
    }
     Matrix operator*(const int iValue)
    {
        Matrix clAns = Matrix(i_Row, i_Column, false);
        for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++)
        {
            for (int iColIndex = 0; iColIndex < i_Column; iColIndex++)
            {
                clAns.iArray[iRowIndex][iColIndex] = iArray[iRowIndex][iColIndex] * iValue;
            }
        }
        return clAns;
    }
     Matrix fn_Transpose()
    {
        Matrix clAns = Matrix(i_Column, i_Row,  false);
         for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < i_Column; iColIndex++)
                {
                     clAns.iArray[iRowIndex][iColIndex] = iArray[iColIndex][iRowIndex];
                }
            }
       return clAns;
    }
    void fn_Print()
    {
         for (int iRowIndex = 0; iRowIndex < i_Row; iRowIndex++)
            {
                for (int iColIndex = 0; iColIndex < i_Column; iColIndex++)
                {
                    cout<<iArray[iRowIndex][iColIndex]<<"\t";
                }
                cout<<endl;
            }
    }
    int*& operator[](const int &index){
    return iArray[index];
    }
};

int main()
{
    int iRow, iColumn;
    cout << "Enter no of rows for Matrix : ";
    cin >> iRow;
    cout << "Enter no of columns for Matrix : ";
    cin >> iColumn;

    Matrix clObjM1(iRow, iColumn, true);
    Matrix clObjM2(iRow, iColumn, true);
    Matrix clObjSum(iRow, iColumn, false);
    Matrix clObjMul(iRow, iColumn, false);
    Matrix clObjSub(iRow, iColumn, false);
    Matrix clObjScalerMul(iRow, iColumn, false);
    Matrix clObjTranspose(iRow, iColumn, false);
    clObjSum=clObjM1+clObjM2;
    clObjSub=clObjM1-clObjM2;
    clObjMul=clObjM1*clObjM2;
    int iValue=10;
    clObjScalerMul=clObjM1*iValue;
    clObjTranspose=clObjM1.fn_Transpose();
   // clObjM1.fn_Print();
   // clObjM2.fn_Print();
   cout<<"Answer of addition of given Array \n";
    clObjSum.fn_Print();
   cout<<"Answer of subtraction of given Array \n";
    clObjSub.fn_Print();
   cout<<"Answer of multiplication of given Array \n";
    clObjMul.fn_Print();
   cout<<"Answer of scaler multiplication of given Array \n";
    clObjScalerMul.fn_Print();
   cout<<"Answer of transpose of given Array \n";
    clObjTranspose.fn_Print();
    int i_RowIndex,i_ColumnIndex;
    cout<<"Enter the Row index that you want to access:";
    cin>>i_RowIndex;
    cout<<"Enter the Column index that you want to access:";
    cin>>i_ColumnIndex;
    cout<<clObjM1[i_RowIndex][i_ColumnIndex];
}
