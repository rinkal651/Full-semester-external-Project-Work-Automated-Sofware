using System;

class BinarySearchTree
{
    public static Boolean bFlag = false;

    public static int iPosition = 0;
    public class Node
    {
        public int iKey;
        public Node clLeft, clRight;

        public Node(int iItem)
        {
            iKey = iItem;
            clLeft = clRight = null;
        }
    }

    Node clRoot;

    // Constructor
    BinarySearchTree()
    {

        clRoot = null;
    }

    // This method mainly calls insertRec()
    void fnInsert(int iKey)
    {
        clRoot = fnInsertRec(clRoot, iKey);
    }

    // A recursive function to insert 
    // a new key in BST 
    Node fnInsertRec(Node clRoot, int iKey)
    {

        // If the tree is empty, 
        // return a new node 
        if (clRoot == null)
        {
            clRoot = new Node(iKey);
            return clRoot;
        }

        // Otherwise, recur down the tree 
        if (iKey < clRoot.iKey)
            clRoot.clLeft = fnInsertRec(clRoot.clLeft, iKey);
        else if (iKey > clRoot.iKey)
            clRoot.clRight = fnInsertRec(clRoot.clRight, iKey);

        // Return the (unchanged) node pointer 
        return clRoot;
    }


    // This method mainly calls deleteRec()
    void fnDeleteKey(int iKey) { clRoot = fnDeleteRec(clRoot, iKey); }

    /* A recursive function to 
      delete an existing key in BST
     */
    Node fnDeleteRec(Node clRoot, int iKey)
    {
        /* Base Case: If the tree is empty */
        if (clRoot == null)
            return clRoot;

        /* Otherwise, recur down the tree */
        if (iKey < clRoot.iKey)
            clRoot.clLeft = fnDeleteRec(clRoot.clLeft, iKey);
        else if (iKey > clRoot.iKey)
            clRoot.clRight = fnDeleteRec(clRoot.clRight, iKey);

        // if key is same as clRoot's key, then This is the
        // node to be deleted
        else
        {
            // node with only one child or no child
            if (clRoot.clLeft == null)
                return clRoot.clRight;
            else if (clRoot.clRight == null)
                return clRoot.clLeft;

            // node with two children: Get the
            // inorder successor (smallest
            // in the clRight subtree)
            clRoot.iKey = fnMinValue(clRoot.clRight);

            // Delete the inorder successor
            clRoot.clRight = fnDeleteRec(clRoot.clRight, clRoot.iKey);
        }
        return clRoot;
    }

    int fnMinValue(Node clRoot)
    {
        int iMinv = clRoot.iKey;
        while (clRoot.clLeft != null)
        {
            iMinv = clRoot.clLeft.iKey;
            clRoot = clRoot.clLeft;
        }
        return iMinv;
    }

    void fnPrintPostorder(Node clNode)
    {
        if (clNode == null)
            return;

        // first recur on clLeft subtree
        fnPrintPostorder(clNode.clLeft);

        // then recur on right subtree
        fnPrintPostorder(clNode.clRight);

        // now deal with the clNode
        Console.Write(clNode.iKey + " ");
    }

    /* Given a binary tree, print
       its clNodes in inorder*/
    void fnPrintInorder(Node clNode)
    {
        if (clNode == null)
            return;

        /* first recur on clLeft child */
        fnPrintInorder(clNode.clLeft);

        /* then print the data of clNode */
        Console.Write(clNode.iKey + " ");

        /* now recur on right child */
        fnPrintInorder(clNode.clRight);
    }

    /* Given a binary tree, print
       its clNodes in preorder*/
    void fnPrintPreorder(Node clNode)
    {
        if (clNode == null)
            return;

        /* first print data of clNode */
        Console.Write(clNode.iKey + " ");

        /* then recur on clLeft subtree */
        fnPrintPreorder(clNode.clLeft);

        /* now recur on right subtree */
        fnPrintPreorder(clNode.clRight);
    }

    // Wrappers over above recursive functions
    void fnPrintPostorder() { fnPrintPostorder(clRoot); }
    void fnPrintInorder() { fnPrintInorder(clRoot); }
    void fnPrintPreorder() { fnPrintPreorder(clRoot); }

    void fnSearchNode(int iValue)
    {
        int iAnswer = fnSearchNode(clRoot, iValue);
        if (iAnswer == 0)
        {
            Console.WriteLine("Node not Found");
        }
        else
        {
            Console.WriteLine("Node Found at position "+iAnswer);
        }
    }

    public int fnSearchNode(Node clNode,int iValue)
    {

        // base case
        if (clNode == null)
            return iPosition;
        iPosition = iPosition + 1;
        /* first print data of clNode */
        Console.Write(clNode.iKey + " ");
        if (clNode.iKey== iValue)
        {
            return iPosition;
        }

        /* then recur on clLeft subtree */
        fnSearchNode(clNode.clLeft, iValue);

        /* now recur on right subtree */
        fnSearchNode(clNode.clRight, iValue);
        return iPosition;
    }
    // Driver Code
    public static void Main(String[] args)
    {
        BinarySearchTree clTree = new BinarySearchTree();
        clTree.fnInsert(50);
        clTree.fnInsert(30);
        clTree.fnInsert(20);
        clTree.fnInsert(40);
        clTree.fnInsert(70);
        Console.WriteLine(
           "Inorder traversal of the modified tree");
        clTree.fnPrintInorder();

        Console.WriteLine("\nInsert 50");

        clTree.fnInsert(50);
        Console.WriteLine(
         "Inorder traversal of the modified tree");
        clTree.fnPrintInorder();

        Console.WriteLine("\nInsert 80");

        clTree.fnInsert(80);

        Console.WriteLine(
           "Inorder traversal of the given tree");
        clTree.fnPrintInorder();

        Console.WriteLine("\nDelete 20");
        clTree.fnDeleteKey(20);
        Console.WriteLine(
            "Inorder traversal of the modified tree");
        clTree.fnPrintInorder();

        Console.WriteLine("\n Pre order traversal of the modified tree");
        clTree.fnPrintPreorder();
        Console.WriteLine("\n Post order traversal of the modified tree");
        clTree.fnPrintPostorder();
        Console.WriteLine("\nDelete 30");
        clTree.fnDeleteKey(30);
        Console.WriteLine(
            "Inorder traversal of the modified tree");
        clTree.fnPrintPreorder();
        int iKey = 80;
        Console.WriteLine("Search Node "+iKey);

        Console.WriteLine("Search Node " + iKey);
        clTree.fnSearchNode(iKey);
    }
}


//