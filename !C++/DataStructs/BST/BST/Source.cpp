#include <iostream>
#include <memory>
#include <string>
#include <random>
#include <vector>
#include "BST.h"
#include "Node.h"

int main()
{
    BST<int> tree;
    std::string input;
    int value;

    while (true)
    {
        std::cout << "I = insert, D = delete, m = minimum, M = maximum, S = search, PO = pre-order, IO = in-order, pO = post-order, BF = breadth first" << std::endl;
        
        //input = Console.ReadLine();
        std::cin >> input;

        if (input == "I")
        {
            std::cout << "What doth thee wanteth to ins'rt?" << std::endl;
            std::cin >> value;
            tree.Insert(value);
            std::cout << "OK" << std::endl;
        }

        if (input == "D")
        {
            std::cout << "What doth thee wanteth to fordid?" << std::endl;
            std::cin >> value;
            tree.Remove(value);
            std::cout << "OK" << std::endl;
        }

        /*if (input == "m")
        {
            std::cout << "Of what sub-tree?" << std::endl;
            std::cin >> value;
            std::cout << tree.Minimum(value).ToString() << std::endl;
        }

        if (input == "M")
        {
            std::cout << "Of what sub-tree?" << std::endl;
            std::cin >> value;
            std::cout << tree.Maximum(value).ToString() << std::endl;
        }*/

        if (input == "S")
        {
            std::cout << "What doth thee wanteth to searcheth f'r?" << std::endl;
            std::cin >> value;
            if (tree.Contains(value))
            {
                std::cout << "" << std::endl;
                std::cout << "This value is somewh're in the tree.  If 't be true thee wanteth to knoweth its exact location, prithee payeth me $5." << std::endl;
            }
            else
            {
                std::cout << "" << std::endl;
                std::cout << "Err'r numb'r 666." << std::endl;
                std::cout << "Eith'r this value is not in the tree, 'r thee oweth me wage." << std::endl;
                std::cout << "Whatev'r the case, i suggesteth yond thee starteth running." << std::endl;
            }
        }

        if (input == "PO")
        {
            std::cout << std::endl;
            std::vector<std::shared_ptr<Node<int>>> thing = tree.PreOrder();
            for (int i = 0; i < thing.size(); i++)
            {
                std::cout << thing[i]->value + ", " << std::endl;
            }
        }

        /*if (input == "IO")
        {
            std::cout << "" << std::endl;
            int[] array = new int[tree.InOrder().Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tree.InOrder()[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                std::cout << array[i] + ", " << std::endl;
            }
        }

        if (input == "pO")
        {
            std::cout << "" << std::endl;
            int[] array = new int[tree.PostOrder().Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tree.PostOrder()[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                std::cout << array[i] + ", " << std::endl;
            }
        }

        if (input == "BF")
        {
            std::cout << "" << std::endl;
            int[] array = new int[tree.BreadthFirst().Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tree.BreadthFirst()[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                std::cout << array[i] + ", " << std::endl;
            }
        }*/

        if (input == "z")
        {
            for (int i = 0; i < 5000; i++)
            {
                tree.Insert(i);
            }
            return 0;
        }


        for (int i = 0; i < 5; i++)
        {
            std::cout << "" << std::endl;
        }
    }
	return 0;
};