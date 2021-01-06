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
        std::cout << "I = insert, D = delete, S = search, PO = pre-order, IO = in-order, pO = post-order" << std::endl;
        
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
                std::cout << "This item is missing" << std::endl;
            }
        }

        if (input == "PO")
        {
            std::cout << std::endl;

            auto thing = tree.PreOrder();            
            for (auto&& item : thing)
            {
                std::cout << item->value << ", ";
            }
            std::cout << std::endl;

            //for (int i = 0; i < thing.size(); i++)
            //{
            //    std::cout << thing[i]->value << ", " << std::endl;
            //}
        }

        if (input == "IO")
        {
            auto thing = tree.InOrder();
            for (int i = 0; i < thing.size(); i++)
            {
                std::cout << thing[i]->value << ", " << std::endl;
            }
        }

        if (input == "pO")
        {
            auto thing = tree.PostOrder();
            for (int i = 0; i < thing.size(); i++)
            {
                std::cout << thing[i]->value << ", " << std::endl;
            }
        }

        if (input == "z")
        {
<<<<<<< HEAD
            tree.Insert(10);
            tree.Insert(2);
=======
            tree.Insert(2);
            tree.Insert(10);
>>>>>>> b2dc5702952169246fe8191433e2e19269f2a585
            tree.Insert(5);
            tree.Insert(20);
            tree.Insert(1);
            tree.Insert(0);
            tree.Insert(9);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(3);
            tree.Insert(18);
            tree.Insert(8);
            tree.Insert(6);
            tree.Insert(17);
            tree.Insert(4);
        }


        for (int i = 0; i < 5; i++)
        {
            std::cout << "" << std::endl;
        }
    }
	return 0;
};